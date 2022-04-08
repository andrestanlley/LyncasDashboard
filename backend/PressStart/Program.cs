using Microsoft.EntityFrameworkCore;
using PressStart.Data;
using PressStart.Interfaces;
using PressStart.Middlewares;
using PressStart.Profiles;
using PressStart.Repositories;
using PressStart.Services;

var builder = WebApplication.CreateBuilder(args);

string mySqlConnection = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(mySqlConnection));

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAutenticacaoService, AutenticacaoService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddCors();
builder.Services.AddControllers()
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling
     = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddAutoMapper(typeof(UsuarioProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware(typeof(ErrorMiddleware));
app.UseMiddleware<AutenticacaoMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.Migrate();
}

app.UseCors(x => x
.AllowAnyHeader()
.AllowAnyMethod()
.SetIsOriginAllowed(origin => true)
.AllowCredentials());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

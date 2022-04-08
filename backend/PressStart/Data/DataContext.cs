using Microsoft.EntityFrameworkCore;
using PressStart.Models;

namespace PressStart.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Autenticacao> Autenticacao { get; set; }

        protected override void OnModelCreating(ModelBuilder mb){
            base.OnModelCreating(mb);

            var pessoa = mb.Entity<Pessoa>();

            pessoa.ToTable("Pessoas");
            pessoa.HasKey(x => x.PessoaId);
            pessoa.Property(x => x.PessoaId).HasColumnName("PessoaId").ValueGeneratedOnAdd();
            pessoa.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(100)").IsRequired();
            pessoa.Property(x => x.Sobrenome).HasColumnName("sobrenome").HasColumnType("varchar(100)").IsRequired();
            pessoa.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(200)").IsRequired();
            pessoa.HasIndex(x => x.Email).IsUnique();
            pessoa.Property(x => x.Telefone).HasColumnName("telefone").HasColumnType("varchar(16)").IsRequired();
            pessoa.Property(x => x.DataNasc).HasColumnName("DataNasc").HasColumnType("datetime");
            pessoa.HasOne(x => x.Autenticacao).WithOne(x => x.Pessoa);

            var autenticacao = mb.Entity<Autenticacao>();

            autenticacao.ToTable("Autenticacao");
            autenticacao.HasKey(x => x.Id);
            autenticacao.Property(x => x.Id).HasColumnName("id").IsRequired();
            autenticacao.Property(x => x.Senha).HasColumnName("senha").HasColumnType("varchar(50)").IsRequired();
            autenticacao.Property(x => x.Estado).HasColumnName("estado").HasColumnType("BIT").IsRequired();

        }
    }
}

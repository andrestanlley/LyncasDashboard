using Microsoft.EntityFrameworkCore;
using PressStart.Data;
using PressStart.Interfaces;
using PressStart.Models;

namespace PressStart.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly DataContext _db;
        public UsuarioRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Pessoa?> ChecarLogin(string Email){
            Pessoa? usuario = await _db.Pessoas.Include(x => x.Autenticacao)
            .SingleOrDefaultAsync(x => x.Email == Email); 
            return usuario;
        }

        public async Task<IEnumerable<Pessoa>> ObterTodos()
        {
            List<Pessoa> usuarios = await _db.Pessoas
            .Include(p => p.Autenticacao)
            .Where(x => x.PessoaId == x.Autenticacao.PessoaId)
            .ToListAsync();

            return usuarios;
        }

        public async Task<Pessoa> Salvar(Pessoa usuario)
        {
            await _db.AddAsync(usuario);
            await _db.SaveChangesAsync();
            
            return usuario;
        }

        public async Task Deletar(Pessoa model)
        {
            _db.Pessoas.Remove(model);
            await _db.SaveChangesAsync();
        }

        public async Task<Pessoa?> ObterPorId(int id)
        {
            return await _db.Pessoas
            .Include(x => x.Autenticacao)
            .SingleOrDefaultAsync(x => x.PessoaId == id);
        }

        public async Task<Pessoa> Atualizar(Pessoa Model)
        {
            _db.Update(Model);
            await _db.SaveChangesAsync();
            return Model;
        }
    }
}

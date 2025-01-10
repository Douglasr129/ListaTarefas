using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;


namespace Data.Repository
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(MeuDbContext db) : base(db)
        {
        }

        public async Task<Tarefa> ObterTarefaPorIdUsuario(Guid id)
        {
            return await Db.tarefa.AsNoTracking()
                .Include(f => f.UsuarioId)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<Tarefa> ObterTarefaPorUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}

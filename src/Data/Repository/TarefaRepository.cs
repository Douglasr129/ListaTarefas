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

        public async Task<IEnumerable<Tarefa>> ObterTarefaPorIdUsuario(Guid id)
        {
            return await Db.tarefa.AsNoTracking()
                .Where(t => t.Id == id)
                .ToListAsync();
        }

        public Task<Tarefa> ObterTarefaPorUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}

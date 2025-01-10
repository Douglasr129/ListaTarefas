using Business.Models;

namespace Business.Interfaces
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        Task<IEnumerable<Tarefa>> ObterTarefaPorIdUsuario(Guid id);
        Task<Tarefa> ObterTarefaPorUsuario(Usuario usuario);
    }
}

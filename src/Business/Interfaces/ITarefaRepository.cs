using Business.Models;

namespace Business.Interfaces
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        Task<Tarefa> ObterTarefaPorIdUsuario(Guid id);
        Task<Tarefa> ObterTarefaPorUsuario(Usuario usuario);
    }
}

using Business.Models;

namespace Business.Interfaces
{
    public interface ITarefaRopository : IRepository<Tarefa>
    {
        Task<Tarefa> ObterTarefaPorId(Guid id);
        Task<Tarefa> ObterTarefaPorIdUsuario(Guid id);
        Task<Tarefa> ObterTarefaPorUsuario(Usuario usuario);
    }
}

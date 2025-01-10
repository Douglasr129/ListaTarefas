using Business.Interfaces;
using Business.Models;
using Business.Models.Validation;


namespace Business.Services
{
    public class TarefaService : BaseService, ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaService(INotificador notificador, 
                             ITarefaRepository tarefaRopository) : base(notificador)
        {
            _tarefaRepository = tarefaRopository;
        }

        public async Task Adicionar(Tarefa tarefa)
        {
            if (!ExecutarValidacao(new TarefaValidation(), tarefa)) return;

            var tarefaExistente = await _tarefaRepository.ObterPorId(tarefa.Id);

            if (tarefaExistente != null)
            {
                Notificar("Já existe uma tarefa com o ID informado!");
                return;
            }

            await _tarefaRepository.Adicionar(tarefa);
        }

        public async Task Atualizar(Tarefa tarefa)
        {
            if (!ExecutarValidacao(new TarefaValidation(), tarefa)) return;

            await _tarefaRepository.Atualizar(tarefa);
        }

        public void Dispose()
        {
            _tarefaRepository?.Dispose();
        }

        public async Task Remover(Guid id)
        {
            await _tarefaRepository.Remover(id);
        }
    }
}

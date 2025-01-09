using Business.Interfaces;
using Business.Models;
using Business.Models.Validation;


namespace Business.Services
{
    internal class TarefaService : BaseService, ITarefaService
    {
        private readonly ITarefaRopository _tarefaRopository;
        public TarefaService(INotificador notificador, 
                             ITarefaRopository tarefaRopository) : base(notificador)
        {
            _tarefaRopository = tarefaRopository;
        }

        public async Task Adicionar(Tarefa tarefa)
        {
            if (!ExecutarValidacao(new TarefaValidation(), tarefa)) return;

            var tarefaExistente = await _tarefaRopository.ObterPorId(tarefa.Id);

            if (tarefaExistente != null)
            {
                Notificar("Já existe um produto com o ID informado!");
                return;
            }

            await _tarefaRopository.Adicionar(tarefa);
        }

        public Task Atualizar(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

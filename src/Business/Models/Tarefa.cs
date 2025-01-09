namespace Business.Models
{
    public class Tarefa : Entity
    {
        public int TarefaId { get; set; }
        public required string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public bool Concluida { get; set; }

        public int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }
    }
}

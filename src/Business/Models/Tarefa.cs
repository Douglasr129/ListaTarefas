namespace Business.Models
{
    public class Tarefa : Entity
    {
        public required string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataConclusao { get; set; }
        public bool Concluida { get; set; }

        public int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }
    }
}

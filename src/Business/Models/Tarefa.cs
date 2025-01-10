namespace Business.Models
{
    public class Tarefa : Entity
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataConclusao { get; set; }
        public bool Concluida { get; set; }

        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}

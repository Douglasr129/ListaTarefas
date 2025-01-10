using Microsoft.AspNetCore.Identity;

namespace Business.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public ICollection<Tarefa>? Tarefas { get; set; }
    }
}

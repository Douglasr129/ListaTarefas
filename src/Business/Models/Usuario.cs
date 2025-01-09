using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Usuario
    {
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public ICollection<Tarefa>? Tarefas { get; set; }
    }
}

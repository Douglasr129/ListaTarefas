using Business.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class TarefaDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [JsonProperty("titulo")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [JsonProperty("descricao")]
        public string? Descricao { get; set; }
        [JsonProperty("dataConclusao")]
        public DateTime? DataConclusao { get; set; }
        [JsonProperty("concluida")]
        public bool Concluida { get; set; }

        public Guid UsuarioId { get; set; }
    }
}

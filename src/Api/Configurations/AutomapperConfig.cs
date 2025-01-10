using Api.Dtos;
using AutoMapper;
using Business.Models;

namespace Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Tarefa, TarefaDto>()
                .ReverseMap();
        }
    }
}

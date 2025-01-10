﻿using Api.Dtos;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TarefaController : MainController
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly ITarefaService _tarefaService;
        private readonly IMapper _mapper;
        private readonly IUser _user;
        public TarefaController(INotificador notificador, IUser appUSer, ITarefaRepository tarefaRepository, ITarefaService tarefaService, IMapper mapper, IUser user) : base(notificador, appUSer)
        {
            _tarefaRepository = tarefaRepository;
            _tarefaService = tarefaService;
            _mapper = mapper;
            _user = user;
        }
        [HttpGet]
        public async Task<IEnumerable<TarefaDto>> ObterTarefas()
        {
            var userId = _user.GetUserId();
            var tarefas = await _tarefaRepository.ObterTarefaPorIdUsuario(userId); 
            return _mapper.Map<IEnumerable<TarefaDto>>(tarefas);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TarefaDto>> ObterTarefasId(Guid id)
        {
            var tarefa = await _tarefaRepository.ObterPorId(id);
            if(tarefa is null) return NotFound();
            
            return _mapper.Map<TarefaDto>(tarefa); ;
        }
        [HttpPost]
        public async Task<ActionResult<TarefaDto>> Adicionar(TarefaDto tarefaDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            tarefaDto.UsuarioId = _user.GetUserId();
            await _tarefaService.Adicionar(_mapper.Map<Tarefa>(tarefaDto));
            return CustomResponse(HttpStatusCode.OK, tarefaDto);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TarefaDto>> Atualizar(Guid id, TarefaDto tarefaDto)
        {
            if(id != tarefaDto.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse();
            }
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _tarefaService.Atualizar(_mapper.Map<Tarefa>(tarefaDto));
            return CustomResponse(HttpStatusCode.OK, tarefaDto);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            await _tarefaService.Remover(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }

    }
}

using Crud_To_Do_List.Data;
using Crud_To_Do_List.DTOs;
using Crud_To_Do_List.Models;
using Crud_To_Do_List.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_To_Do_List.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TarefasController : ControllerBase
{
    private readonly ITarefaRepository _repository;

    // Agora o controller recebe o Repository, não mais o DbContext diretamente..
    public TarefasController(ITarefaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<List<TarefaResponseDto>> ListarTarefas()
    {
        var tarefas = _repository.ListarTodas();

        //converte cada tarefa (model) para TarefaResponseDto usando LINQ
        var reponse = tarefas.Select(t => new TarefaResponseDto
        {
            Id = t.Id,
            Titulo = t.Titulo,
            Descricao = t.Descricao,
            Concluida = t.Concluida,
            DataCriacao = t.DataCriacao
        }).ToList();

        return Ok(reponse);
    }

    [HttpGet("{id}")]
    public ActionResult<TarefaResponseDto> ObterTarefa(int id)
    {
        var tarefa = _repository.ObterPorId(id);
        if (tarefa == null)
            return NotFound();

        var response = new TarefaResponseDto
        {
            Id = tarefa.Id,
            Titulo = tarefa.Titulo,
            Descricao = tarefa.Descricao,
            Concluida = tarefa.Concluida,
            DataCriacao = tarefa.DataCriacao
        };

        return Ok(response);
    }

    [HttpPost("CriarTarefa")]
    public ActionResult<TarefaResponseDto> CriarTarefa(TarefaRequestDTO dto)
    {
        //Converte o DTO recebido em um model para salvar no banco
        var NovaTarefa = new Tarefa
        {
            Titulo = dto.Titulo,
            Descricao = dto.Descricao,
            Concluida = dto.Concluida,
            DataCriacao = DateTime.Now
        };

        _repository.Criar(NovaTarefa);

        var response = new TarefaResponseDto
        {
            Id = NovaTarefa.Id,
            Titulo = NovaTarefa.Titulo,
            Descricao = NovaTarefa.Descricao,
            Concluida = NovaTarefa.Concluida,
            DataCriacao = NovaTarefa.DataCriacao
        };

        return CreatedAtAction(nameof(ObterTarefa), new { id = NovaTarefa.Id }, response);
    }

    [HttpPut("AtualizarTarefa/{id}")]
    public ActionResult AtualizarTarefa(int id, TarefaRequestDTO dto)
    {
        var tarefa = _repository.ObterPorId(id);
        if (tarefa == null)
            return NotFound();

        // Atualiza o Model com os dados do DTO
        tarefa.Titulo = dto.Titulo;
        tarefa.Descricao = dto.Descricao;
        tarefa.Concluida = dto.Concluida;
        _repository.Atualizar(tarefa);

        return NoContent();
    }

    [HttpDelete("ExcluirTarefa/{id}")]
    public ActionResult ExcluirTarefa(int id)
    {
        var tarefa = _repository.ObterPorId(id);
        if (tarefa == null)
            return NotFound();

        _repository.Deletar(tarefa);
        return NoContent();
    }
}



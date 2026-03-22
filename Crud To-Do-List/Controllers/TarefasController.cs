using Crud_To_Do_List.Data;
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
    public ActionResult<List<Tarefa>> ListarTarefas()
    {
        return Ok(_repository.ListarTodas());
    }

    [HttpGet("{id}")]
    public ActionResult<Tarefa> ObterTarefa(int id)
    {
        var tarefa = _repository.ObterPorId(id);
        if (tarefa == null)
            return NotFound();
        return Ok(tarefa);
    }

    [HttpPost("CriarTarefa")]
    public ActionResult<Tarefa> CriarTarefa(Tarefa novaTarefa)
    {
        if (string.IsNullOrWhiteSpace(novaTarefa.Titulo))
            return BadRequest("O título é obrigatório.");  
        
        novaTarefa.DataCriacao = DateTime.UtcNow;
        _repository.Criar(novaTarefa);

        return CreatedAtAction(nameof(ObterTarefa), new { id = novaTarefa.Id }, novaTarefa);
    }

    [HttpPut("AtualizarTarefa/{id}")]
    public ActionResult AtualizarTarefa(int id, Tarefa tarefaAtualizada)
    {
        var tarefa = _repository.ObterPorId(id);
        if (tarefa == null)
            return NotFound();

        tarefa.Titulo = tarefaAtualizada.Titulo;
        tarefa.Descricao = tarefaAtualizada.Descricao;
        tarefa.Concluida = tarefaAtualizada.Concluida;
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



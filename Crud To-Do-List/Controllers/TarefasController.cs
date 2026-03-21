using Crud_To_Do_List.Data;
using Crud_To_Do_List.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_To_Do_List.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TarefasController : ControllerBase
{
    private readonly AppDbContext? _context;

    public TarefasController(AppDbContext? context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Tarefa>> ListarTarefas()
    {
        return Ok(_context.Tarefas.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<Tarefa> ObterTarefa(int id)
    {
        var tarefa = _context.Tarefas.Find(id);
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
        _context.Tarefas.Add(novaTarefa);
        _context.SaveChanges();

        return CreatedAtAction(nameof(ObterTarefa), new { id = novaTarefa.Id }, novaTarefa);
    }

    [HttpPut("AtualizarTarefa/{id}")]
    public ActionResult AtualizarTarefa(int id, Tarefa tarefaAtualizada)
    {
        var tarefa = _context.Tarefas.Find(id);
        if (tarefa == null)
            return NotFound();

        tarefa.Titulo = tarefaAtualizada.Titulo;
        tarefa.Descricao = tarefaAtualizada.Descricao;
        tarefa.Concluida = tarefaAtualizada.Concluida;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("ExcluirTarefa/{id}")]
    public ActionResult ExcluirTarefa(int id)
    {
        var tarefa = _context.Tarefas.Find(id); 
        if (tarefa == null)
            return NotFound();

        _context.Tarefas.Remove(tarefa);
        _context.SaveChanges();

        return NoContent();
    }
}



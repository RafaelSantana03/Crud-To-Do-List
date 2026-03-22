using Crud_To_Do_List.Data;
using Crud_To_Do_List.Models;

namespace Crud_To_Do_List.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly AppDbContext _context;

    // O DbContext é injetado aqui - O Repository é o único lugar onde o DbContext é usado, isolando a lógica de acesso a dados do restante da aplicação.
    public TarefaRepository(AppDbContext context)
    {
        _context = context;
    }
    public List<Tarefa> ListarTodas()
    {
        return _context.Tarefas.ToList();
    }
    public Tarefa? ObterPorId(int id)
    {
        return _context.Tarefas.Find(id);
    }
    public void Criar(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        _context.SaveChanges();
    }
    public void Atualizar(Tarefa tarefa)
    {
        _context.Tarefas.Update(tarefa);
        _context.SaveChanges();
    }
    public void Deletar(Tarefa tarefa)
    {
        _context.Tarefas.Remove(tarefa);
        _context.SaveChanges();
    }

}

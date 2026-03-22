using Crud_To_Do_List.Models;   
namespace Crud_To_Do_List.Repositories;

public interface ITarefaRepository
{
    List<Tarefa> ListarTodas();
    Tarefa? ObterPorId(int id);
    void Criar(Tarefa tarefa);
    void Atualizar(Tarefa tarefa);
    void Deletar(Tarefa tarefa);
}

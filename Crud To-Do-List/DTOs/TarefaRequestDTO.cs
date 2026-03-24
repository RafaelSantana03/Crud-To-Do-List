namespace Crud_To_Do_List.DTOs;

public class TarefaRequestDTO
{
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public bool Concluida { get; set; }
}
namespace Crud_To_Do_List.DTOs;

public class TarefaResponseDto
{
    public int Id { get; set; }
    public string? Titulo { get; set; } 
    public string? Descricao { get; set; } 
    public bool Concluida { get; set; }
    public DateTime DataCriacao { get; set; }
}
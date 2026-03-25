using System.ComponentModel.DataAnnotations;

namespace Crud_To_Do_List.DTOs;

public class TarefaRequestDTO
{
    [Required(ErrorMessage = "O título é obrigatório.")]
    [MinLength(3, ErrorMessage = "O título deve conter pelo menos 3 caracteres.")]
    [MaxLength(100, ErrorMessage = "O título deve conter no máximo 100 caracteres.")]
    public string? Titulo { get; set; }

    [MaxLength(500, ErrorMessage = "A descrição deve conter no máximo 500 caracteres.")]
    public string? Descricao { get; set; }
    public bool Concluida { get; set; }
}
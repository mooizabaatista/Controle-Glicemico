using Application.DTOs.ControleGlicemico;

namespace Ui.Models;

public class ControleGlicemicoVM
{
    public List<ControleGlicemicoDto> ControleGlicemicoList { get; set; } = new List<ControleGlicemicoDto>();
    public ControleGlicemicoDto ControleGlicemicoDto { get; set; } = new ControleGlicemicoDto();
}
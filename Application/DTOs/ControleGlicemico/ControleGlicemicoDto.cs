using Domain.Enums;

namespace Application.DTOs.ControleGlicemico;

public class ControleGlicemicoDto
{
    public long Id { get; set; }
    public DateTime Data { get; set; }
    public int ValorGlicemico { get; set; }
    public Periodo Periodo { get; set; }
}
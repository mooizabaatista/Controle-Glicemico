using Domain.Enums;

namespace Domain.Entities;

public class ControleGlicemico
{
    public long Id { get; set; }
    public DateTime Data { get; set; }
    public int ValorGlicemico { get; set; }
    public Periodo Periodo { get; set; }
}
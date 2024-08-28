using Application.DTOs.ControleGlicemico;
using Domain.Entities;

namespace Application.Interfaces;

public interface IControleGlicemicoService
{
    Task<List<ControleGlicemicoDto>> GetAll();
    Task<ControleGlicemicoDto?> GetById(long id);
    Task<ControleGlicemico> Create(ControleGlicemicoDto controleGlicemico);
    Task<ControleGlicemico> Update(ControleGlicemicoDto controleGlicemico);
    Task<bool> Delete(long id);
}
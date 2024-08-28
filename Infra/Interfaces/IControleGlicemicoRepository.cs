using Domain.Entities;

namespace Infra.Interfaces;

public interface IControleGlicemicoRepository
{
    Task<List<ControleGlicemico>> GetAll();
    Task<ControleGlicemico?> GetById(long id);
    Task<ControleGlicemico> Create(ControleGlicemico controleGlicemico);
    Task<ControleGlicemico> Update(ControleGlicemico controleGlicemico);
    Task<bool> Delete(long id);
}
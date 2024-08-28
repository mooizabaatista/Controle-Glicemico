using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class ControleGlicemicoRepository : IControleGlicemicoRepository
{
    private readonly GliceControlContext _context;

    public ControleGlicemicoRepository(GliceControlContext context)
    {
        _context = context;
    }

    public async Task<List<ControleGlicemico>> GetAll()
    {
        return await _context.ControleGlicemico.ToListAsync();
    }

    public async Task<ControleGlicemico?> GetById(long id)
    {
        return await _context.ControleGlicemico.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<ControleGlicemico> Create(ControleGlicemico controleGlicemico)
    {
        long id = 0;

        long ultimoIdCadastrado = GetAll().Result.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();

        if (ultimoIdCadastrado != 0)
            id = (int)ultimoIdCadastrado + 1;

        controleGlicemico.Id = id;

        var result = _context.ControleGlicemico.Add(controleGlicemico).Entity;
        await _context.SaveChangesAsync();
        return result;
    }

    public async Task<ControleGlicemico> Update(ControleGlicemico controleGlicemico)
    {
        var result = _context.ControleGlicemico.Update(controleGlicemico).Entity;
        await _context.SaveChangesAsync();
        return result;
    }

    public async Task<bool> Delete(long id)
    {
        var entityExists = await GetById(id);
        if (entityExists == null)
            return false;

        _context.ControleGlicemico.Remove(entityExists);
        await _context.SaveChangesAsync();
        return true;
    }
}
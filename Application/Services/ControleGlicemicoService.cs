using Application.DTOs.ControleGlicemico;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infra.Interfaces;

namespace Application.Services;
public class ControleGlicemicoService : IControleGlicemicoService
{
    private readonly IControleGlicemicoRepository _repository;
    private readonly IMapper _mapper;

    public ControleGlicemicoService(IControleGlicemicoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ControleGlicemicoDto>> GetAll()
    {
        var entites = await _repository.GetAll();
        return _mapper.Map<List<ControleGlicemicoDto>>(entites);
    }

    public async Task<ControleGlicemicoDto?> GetById(long id)
    {
        var entity = await _repository.GetById(id);
        return _mapper.Map<ControleGlicemicoDto>(entity);
    }

    public async Task<ControleGlicemico> Create(ControleGlicemicoDto controleGlicemico)
    {
        var entity = _mapper.Map<ControleGlicemico>(controleGlicemico);
        return await _repository.Create(entity);
    }

    public async Task<ControleGlicemico> Update(ControleGlicemicoDto controleGlicemico)
    {
        var entity = _mapper.Map<ControleGlicemico>(controleGlicemico);
        return await _repository.Update(entity);
    }

    public async Task<bool> Delete(long id)
    {
        return await _repository.Delete(id);
    }
}
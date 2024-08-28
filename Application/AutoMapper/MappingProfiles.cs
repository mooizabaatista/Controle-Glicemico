using Application.DTOs.ControleGlicemico;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ControleGlicemico, ControleGlicemicoDto>().ReverseMap();
    }
}
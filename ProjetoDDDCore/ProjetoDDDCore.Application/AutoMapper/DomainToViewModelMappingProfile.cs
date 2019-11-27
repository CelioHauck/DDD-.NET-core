using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ProjetoDDDCore.Application.ViewModels;
using ProjetoDDDCore.Domain.Entities;

namespace ProjetoDDDCore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<ClienteViewModel, Cliente>();
        }
    }
}

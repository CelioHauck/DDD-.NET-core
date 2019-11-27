using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ProjetoDDDCore.Application.ViewModels;
using ProjetoDDDCore.Domain.Entities;

namespace ProjetoDDDCore.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Cliente, ClienteViewModel>();
        }
    }
}

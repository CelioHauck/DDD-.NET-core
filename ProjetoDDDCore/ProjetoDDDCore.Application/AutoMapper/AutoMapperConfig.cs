using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ProjetoDDDCore.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}

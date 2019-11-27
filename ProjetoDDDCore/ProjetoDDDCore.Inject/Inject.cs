using Microsoft.Extensions.DependencyInjection;
using ProjetoDDDCore.Application.Service;
using System;
using System.Collections.Generic;
using System.Text;
using ProjetoDDDCore.Application.Interface;
using ProjetoDDDCore.Application.jwt.factory;
using ProjetoDDDCore.Domain.Interfaces.Repositories;
using ProjetoDDDCore.Domain.Interfaces.Services;
using ProjetoDDDCore.Domain.Services;
using ProjetoDDDCore.Infra.Data.Repositories;

namespace ProjetoDDDCore.Inject
{
    public class Inject
    {
        public static void InjetarDependencias(IServiceCollection services)
        {

            //Aplication
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();

            //Domain
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IUsuarioService, UsuarioService>();


            //Infra
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddSingleton<IJwtFactory, JwtFactory>();
        }
    }
}

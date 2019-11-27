using System;
using System.Collections.Generic;
using System.Text;
using ProjetoDDDCore.Application.Interface;
using ProjetoDDDCore.Domain.Entities;
using ProjetoDDDCore.Domain.Interfaces.Services;

namespace ProjetoDDDCore.Application.Service
{
    public class UsuarioAppService: AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuario): base(usuario)
        {
            _usuarioService = usuario;
        }

        public Usuario BuscarUsuario(Usuario usuario)
        {
            return _usuarioService.BuscarUsuario(usuario);
        }
    }
}

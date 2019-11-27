using System;
using System.Collections.Generic;
using System.Text;
using ProjetoDDDCore.Domain.Entities;
using ProjetoDDDCore.Domain.Interfaces.Repositories;
using ProjetoDDDCore.Domain.Interfaces.Services;

namespace ProjetoDDDCore.Domain.Services
{
    public class UsuarioService: ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario BuscarUsuario(Usuario usuario)
        {
            return _usuarioRepository.BuscarUsuario(usuario);
        }
    }
}

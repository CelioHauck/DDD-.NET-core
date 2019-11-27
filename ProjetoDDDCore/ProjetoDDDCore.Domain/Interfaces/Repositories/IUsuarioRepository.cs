using System;
using System.Collections.Generic;
using System.Text;
using ProjetoDDDCore.Domain.Entities;

namespace ProjetoDDDCore.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository: IRepositoryBase<Usuario>
    {
        Usuario BuscarUsuario(Usuario usuario);
    }
}

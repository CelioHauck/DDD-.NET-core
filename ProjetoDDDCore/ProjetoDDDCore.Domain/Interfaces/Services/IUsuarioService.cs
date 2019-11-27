using System;
using System.Collections.Generic;
using System.Text;
using ProjetoDDDCore.Domain.Entities;

namespace ProjetoDDDCore.Domain.Interfaces.Services
{
    public interface IUsuarioService: IServiceBase<Usuario>
    {
        Usuario BuscarUsuario(Usuario usuario); 
    }
}

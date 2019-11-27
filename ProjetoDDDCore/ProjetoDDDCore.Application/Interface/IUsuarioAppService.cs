using System;
using System.Collections.Generic;
using System.Text;
using ProjetoDDDCore.Domain.Entities;

namespace ProjetoDDDCore.Application.Interface
{
    public interface IUsuarioAppService: IAppServiceBase<Usuario>
    {
        Usuario BuscarUsuario(Usuario usuario);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ProjetoDDDCore.Domain.Entities;

namespace ProjetoDDDCore.Application.Interface
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspecias();
    }
}

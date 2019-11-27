using System;
using System.Collections.Generic;
using System.Text;
using ProjetoDDDCore.Domain.Entities;

namespace ProjetoDDDCore.Domain.Interfaces.Services
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes);
    }
}

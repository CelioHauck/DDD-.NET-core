using System;
using System.Collections.Generic;
using System.Text;
using ProjetoDDDCore.Application.Interface;
using ProjetoDDDCore.Domain.Entities;
using ProjetoDDDCore.Domain.Interfaces.Services;

namespace ProjetoDDDCore.Application.Service
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService) : base(clienteService)
        {
            _clienteService = clienteService;
        }

        public IEnumerable<Cliente> ObterClientesEspecias()
        {
            return _clienteService.ObterClientesEspeciais(_clienteService.GetAll());
        }
    }
}

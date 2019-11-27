using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoDDDCore.Application.Interface;
using ProjetoDDDCore.Application.ViewModels;
using ProjetoDDDCore.Domain.Entities;

namespace ProjetoDDDCore.Api.Controllers
{
    [Produces("application/json")]
    [Authorize(Policy = "UsuarioApi")]
    [Route("api/Cliente")]
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clienteApp;

        public ClienteController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.GetAll());
            return Ok(clienteViewModel);
        }

        [HttpGet("clientes-especiais")]
        public IActionResult GetAllClienteEspeciais()
        {
            var clientesViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.ObterClientesEspecias());
            return (clientesViewModel != null) ? (IActionResult) Ok(clientesViewModel) : BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);
            return (clienteViewModel != null) ?  (IActionResult) Ok(clienteViewModel): BadRequest();
        }

        [HttpPost]
        public IActionResult Add([FromBody]ClienteViewModel clienteViewModel)
        {
            var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
            _clienteApp.Add(clienteDomain);
            return Ok(clienteViewModel);
        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromBody]ClienteViewModel clienteViewModel)
        {
            var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
            _clienteApp.Update(clienteDomain);
            return Ok(clienteViewModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var cliente = _clienteApp.GetById(id);
                _clienteApp.Remove(cliente);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProjetoDDDCore.Application.Helper;
using ProjetoDDDCore.Application.Interface;
using ProjetoDDDCore.Application.jwt;
using ProjetoDDDCore.Application.jwt.factory;
using ProjetoDDDCore.Application.ViewModels;
using ProjetoDDDCore.Domain.Entities;

namespace ProjetoDDDCore.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppService _usuarioApp;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;


        public UsuarioController(IUsuarioAppService usuarioApp, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            _usuarioApp = usuarioApp;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
        }

        [HttpPost]
        public IActionResult Add([FromBody]UsuarioViewModel usuarioViewModel)
        {
            var usuarioDomain = Mapper.Map<UsuarioViewModel, Usuario >(usuarioViewModel);
            _usuarioApp.Add(usuarioDomain);
            return Ok(usuarioViewModel);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]UsuarioViewModel usuarioViewModel)
        {
            var usuarioDomain = Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);
            var usuarioRecuperado =  _usuarioApp.BuscarUsuario(usuarioDomain);
            if( usuarioRecuperado == null){ return Ok(usuarioRecuperado);}
            var ident = await GetClaimsIdentity(usuarioRecuperado);
            var jwt = await Tokens.GenerateJwt(ident, _jwtFactory, usuarioRecuperado.Nome, _jwtOptions);
            return Ok(jwt);
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(Usuario usuario)
        {
              return  await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(usuario.Nome, usuario.UsuarioId));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var usuario = _usuarioApp.GetById(id);
                _usuarioApp.Remove(usuario);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
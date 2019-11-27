using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoDDDCore.Domain.Entities;
using ProjetoDDDCore.Domain.Interfaces.Repositories;
using ProjetoDDDCore.Infra.Data.Context;

namespace ProjetoDDDCore.Infra.Data.Repositories
{
    public class UsuarioRepository: RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ProjetoContext dataContext) : base(dataContext)
        {
        }

        public Usuario BuscarUsuario(Usuario usuario)
        {
            return Db.Usuarios.Where(u => u.Nome == usuario.Nome && usuario.Senha == u.Senha).SingleOrDefault(); 
        }

    }
}

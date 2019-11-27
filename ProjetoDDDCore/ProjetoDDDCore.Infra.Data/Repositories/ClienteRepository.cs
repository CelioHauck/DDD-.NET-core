using System;
using System.Collections.Generic;
using System.Text;
using ProjetoDDDCore.Domain.Entities;
using ProjetoDDDCore.Domain.Interfaces.Repositories;
using ProjetoDDDCore.Infra.Data.Context;

namespace ProjetoDDDCore.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(ProjetoContext dataContext) : base(dataContext)
        {

        }
    }
}

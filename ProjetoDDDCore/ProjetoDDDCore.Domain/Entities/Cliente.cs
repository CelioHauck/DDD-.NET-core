using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDCore.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }

        public bool ClienteEspecial(Cliente cliente)
        {
            return DateTime.Now.Year - cliente.DataCadastro.Year >= 5;
        }
    }
}

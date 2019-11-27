using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDCore.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId {get; set;}
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}

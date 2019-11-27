using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDDCore.Application.ViewModels
{
    public class ClienteViewModel
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}

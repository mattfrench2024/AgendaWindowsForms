using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaWindowsForms_EDD2.models
{
    public class Telefone
    {
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public bool Principal { get; set; }

        public Telefone() { }

        public Telefone(string tipo, string numero, bool principal)
        {
            Tipo = tipo;
            Numero = numero;
            Principal = principal;
        }

        public override string ToString()
        {
            return $"{Tipo}: {Numero}" + (Principal ? " (Principal)" : "");
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace AgendaWindowsForms_EDD2.models
{
    public class Agenda
    {
        public List<Contato> Contatos { get; private set; }

        public Agenda()
        {
            Contatos = new List<Contato>();
        }

        public bool Adicionar(Contato c)
        {
            if (Contatos.Any(x => x.Email == c.Email))
                return false; // já existe
            Contatos.Add(c);
            return true;
        }

        public Contato Pesquisar(string email)
        {
            return Contatos.FirstOrDefault(c => c.Email == email);
        }

        public bool Alterar(Contato c)
        {
            var existente = Pesquisar(c.Email);
            if (existente == null) return false;

            existente.Nome = c.Nome;
            existente.DtNasc = c.DtNasc;
            existente.Telefones = c.Telefones;
            return true;
        }

        public bool Remover(string email)
        {
            var c = Pesquisar(email);
            if (c == null) return false;
            Contatos.Remove(c);
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaWindowsForms_EDD2.models
{
    public class Contato
    {
        public override int GetHashCode()
        {
            return Email != null ? Email.GetHashCode() : 0;
        }

        public string Email { get; set; }
        public string Nome { get; set; }
        public Data DtNasc { get; set; }
        public List<Telefone> Telefones { get; set; } = new List<Telefone>();

        public Contato() { }

        public Contato(string nome, string email, Data dtNasc)
        {
            Nome = nome;
            Email = email;
            DtNasc = dtNasc;
        }

        public int GetIdade()
        {
            var hoje = DateTime.Now;
            int idade = hoje.Year - DtNasc.Ano;
            if (hoje.Month < DtNasc.Mes || (hoje.Month == DtNasc.Mes && hoje.Day < DtNasc.Dia))
                idade--;
            return idade;
        }

        public void AdicionarTelefone(Telefone t)
        {
            Telefones.Add(t);
        }

        public string GetTelefonePrincipal()
        {
            var tel = Telefones.FirstOrDefault(t => t.Principal);
            return tel != null ? tel.Numero : "Não definido";
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Email: {Email}, Nascimento: {DtNasc}, Telefone Principal: {GetTelefonePrincipal()}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Contato c)
                return this.Email == c.Email;
            return false;
        }
    }
}

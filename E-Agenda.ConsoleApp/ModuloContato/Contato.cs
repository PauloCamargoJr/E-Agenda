using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp.Compartilhado;

namespace E_Agenda.ConsoleApp.ModuloContato
{
    public class Contato : EntidadeBase
    {

        private readonly string email;
        private readonly string telefone;
        private readonly string empresa;
        private readonly string cargo;

        public Contato(string nome, string email, string telefone, string empresa, string cargo)
        {
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            this.empresa = empresa;
            this.cargo = cargo;
        }

        public override string ToString()
        {
            return "Id: " + numero + Environment.NewLine +
                "Nome: " + nome + Environment.NewLine +
                "email: " + email + Environment.NewLine +
                "telefone: " + telefone + Environment.NewLine +
                "empresa: " + empresa+ Environment.NewLine +
                "cargo: " + cargo + Environment.NewLine;

        }

    }
}

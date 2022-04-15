using System;
using E_Agenda.ConsoleApp.Compartilhado;

namespace E_Agenda.ConsoleApp.ModuloCompromisso
{
    public class Compromisso : EntidadeBase
    {

        private readonly string assunto;
        private readonly string local;
        private readonly DateTime data;
        private readonly int horaInicio;
        private readonly int horaTermino;

        public Compromisso(string nome, string assunto, string local, DateTime data, int horaInicio, int horaTermino)
        {

            this.nome = nome;
            this.assunto = assunto;
            this.local = local;
            this.data = data;
            this.horaInicio = horaInicio;
            this.horaTermino = horaTermino;

        }

        public override string ToString()
        {
            return "Número: " + numero + Environment.NewLine +
                   "Nome: " + nome + Environment.NewLine +
                   "Assunto: " + assunto + Environment.NewLine +
                   "Local: " + local + Environment.NewLine +
                   "Data: " + data + Environment.NewLine +
                   "Hora de inicio: " + horaInicio + Environment.NewLine +
                   "Hora  de termino: " + horaTermino + Environment.NewLine;
        }

    }
}

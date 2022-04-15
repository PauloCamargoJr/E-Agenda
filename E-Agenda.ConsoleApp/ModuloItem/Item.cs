using System;
using E_Agenda.ConsoleApp.Compartilhado;

namespace E_Agenda.ConsoleApp.ModuloItem
{
    public class Item : EntidadeBase
    {

        private DescricaoItem descricao;

        public void ConcluirItem()
        {

            descricao = DescricaoItem.concluido;

        }

        public override string ToString()
        {
            return "Número: " + numero + Environment.NewLine +
                   "Nome: " + nome + Environment.NewLine +
                   "Descrição: " + descricao + Environment.NewLine;
        }

    }
}

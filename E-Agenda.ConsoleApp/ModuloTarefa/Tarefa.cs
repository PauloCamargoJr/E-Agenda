using System;
using System.Collections.Generic;
using E_Agenda.ConsoleApp.Compartilhado;
using E_Agenda.ConsoleApp.ModuloItem;

namespace E_Agenda.ConsoleApp.ModuloTarefa
{
    public class Tarefa : EntidadeBase
    {

        private readonly DateTime dataCriacao;
        private readonly DateTime dataConclusao;
        private double percentualConcluido;
        private readonly string prioridade;
        private List<Item> itens;

        public Tarefa(String nome, DateTime dataCriacao, string prioridade, List<Item> itens)
        {

            this.nome = nome;
            this.dataCriacao = dataCriacao;
            this.prioridade = prioridade;
            this.itens = itens;

        }

        public Tarefa(String nome, string prioridade, List<Item> itens)
        {

            this.nome = nome;
            this.prioridade = prioridade;
            this.itens = itens;

        }

        public string Prioridade 
        { 
        
            get { return prioridade; }

        }

        public override string ToString()
        {
            return "Id: " + numero + Environment.NewLine +
                "Nome: " + nome + Environment.NewLine +
                "Prioridade: " + prioridade + Environment.NewLine +
                "Percentual Concluido: " + percentualConcluido + "%" + Environment.NewLine +
                "Data de criação: " + dataCriacao.ToShortDateString() + Environment.NewLine +
                "Itens: \n" + ListaDeItens() + Environment.NewLine;
                
        }

        private string ListaDeItens()
        {

            string listaDeItens = "";

            foreach (Item item in itens)
            {

                listaDeItens += "->" + item.nome + "\n";

            }

            return listaDeItens;

        }

        public void ConcluirItemTarefa()
        {

            double pesoItem = 100 / itens.Count;
            percentualConcluido += (int)pesoItem;

        }

    }
}

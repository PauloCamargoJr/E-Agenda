using System;
using E_Agenda.ConsoleApp.ModuloTarefa;
using E_Agenda.ConsoleApp.ModuloContato;
using E_Agenda.ConsoleApp.ModuloCompromisso;

namespace E_Agenda.ConsoleApp.Compartilhado
{
    public class TelaMenuPrincipal
    {
        
        private RepositorioTarefa repositorioTarefa;
        private TelaCadastroTarefa telaCadastroTarefa;

        private RepositorioContato repositorioContato;
        private TelaCadastroContato telaCadastroContato;

        private RepositorioCompromisso repositorioCompromisso;
        private  TelaCadastroCompromisso telaCadastroCompromisso;


        public TelaMenuPrincipal(Notificador notificador)
        {

            repositorioTarefa = new RepositorioTarefa();
            telaCadastroTarefa = new TelaCadastroTarefa(repositorioTarefa, notificador);

            repositorioContato = new RepositorioContato();
            telaCadastroContato = new TelaCadastroContato(repositorioContato, notificador);

            repositorioCompromisso = new RepositorioCompromisso();
            telaCadastroCompromisso = new TelaCadastroCompromisso(repositorioCompromisso, notificador);

        }

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("E-Agenda");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Gerenciar Tarefas");
            Console.WriteLine("Digite 2 para Gerenciar Contatos");
            Console.WriteLine("Digite 3 para Gerenciar Compromissos");


            Console.WriteLine("Digite s para sair");

            string opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }

        public TelaBase ObterTela()
        {
            string opcao = MostrarOpcoes();

            TelaBase tela = null;

            if (opcao == "1")
                tela = telaCadastroTarefa;
            else if (opcao == "2")
                tela = telaCadastroContato;
            else if (opcao == "3")
                tela = telaCadastroCompromisso;

            return tela;
        }
    }
}

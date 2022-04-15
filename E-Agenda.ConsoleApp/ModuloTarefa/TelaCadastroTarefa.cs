using System;
using System.Collections.Generic;
using E_Agenda.ConsoleApp.Compartilhado;
using E_Agenda.ConsoleApp.ModuloItem;

namespace E_Agenda.ConsoleApp.ModuloTarefa
{
    public class TelaCadastroTarefa : TelaBase, ITelaCadastravel
    {

        private readonly RepositorioTarefa _repositorioTarefa;
        private readonly Notificador _notificador;

        public TelaCadastroTarefa(RepositorioTarefa repositorioTarefa, Notificador notificador) : base("Cadastro Tarefas")
        {

            _repositorioTarefa = repositorioTarefa;
            _notificador = notificador;

        }

        public void Inserir()
        {

            MostrarTitulo("Cadastro de tarefas");

            Tarefa novaTarefa = ObterTarefa();

            _repositorioTarefa.Inserir(novaTarefa);

            _notificador.ApresentarMensagem("Tarefa cadastrado com sucesso!", TipoMensagem.Sucesso);

        }

        public void Editar()
        {
            MostrarTitulo("Editando a tarefa");

            bool temTarefasCadastradas = VisualizarRegistros("Pesquisando");

            if (temTarefasCadastradas == false)
            {
                _notificador.ApresentarMensagem("Nenhuma Tarefa cadastrada para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroMedicamento = ObterNumeroRegistro();

            Tarefa tarefaAtualizada = ObterTarefaAtualizada();

            bool conseguiuEditar = _repositorioTarefa.Editar(numeroMedicamento, tarefaAtualizada);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Tarefa editada com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Trefa");

            bool temMedicamentosRegistrados = VisualizarRegistros("Pesquisando");

            if (temMedicamentosRegistrados == false)
            {
                _notificador.ApresentarMensagem("Nenhuma Tarefa cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroTarefa = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioTarefa.Excluir(numeroTarefa);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Tarefa excluído com sucesso1", TipoMensagem.Sucesso);
        }

        private Tarefa ObterTarefa()
        {

            List<Item> listaItens = new List<Item>();
            

            Console.WriteLine("Digite o titulo da tarefa: ");

            string nome = Console.ReadLine();

            Console.WriteLine("Digite a prioridade da tarefa(baixa, media, alta): ");
            string prioridade = Console.ReadLine();


            DateTime data = DateTime.Now;
            do 
            {
                Item item = new Item();

                Console.WriteLine("Insira um item da tarefa: ");
                item.nome = Console.ReadLine();

                listaItens.Add(item);

                Console.WriteLine("Insira 1 para adicionar outro item para a tarefa: ");
                if (!(Console.ReadLine() == "1"))
                    break;
            
            } while (true);

            return new Tarefa(nome, data, prioridade, listaItens);
        }

        private Tarefa ObterTarefaAtualizada()
        {

            List<Item> listaItens = new List<Item>();

            Console.WriteLine("Digite o titulo da tarefa: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Insira a prioride da tarefa(baixa, media, alta): ");
            string prioridade = Console.ReadLine();

            do
            {
                Item item = new Item();

                Console.WriteLine("Insira um item da tarefa: ");
                item.nome = Console.ReadLine();

                listaItens.Add(item);

                Console.WriteLine("Insira 1 para adicionar outro item para a tarefa: ");
                if (!(Console.ReadLine() == "1"))
                    break;

            } while (true);

            return new Tarefa(nome, prioridade, listaItens);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Tarefas");

            List<Tarefa> tarefas = _repositorioTarefa.SelecionarTodos();

            if (tarefas.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhuma tarefa disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Tarefa tarefa in tarefas)
                if(tarefa.Prioridade == "alta")
                    Console.WriteLine(tarefa.ToString());

            foreach (Tarefa tarefa in tarefas)
            {

                if (tarefa.Prioridade == "media")
                    Console.WriteLine(tarefa.ToString());

            }

            foreach (Tarefa tarefa in tarefas)
            {

                if (tarefa.Prioridade == "baixa")
                    Console.WriteLine(tarefa.ToString());

            }

            Console.ReadLine();

            return true;
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID da tarefa que deseja editar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioTarefa.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID da tarefa não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }

        public void ConcluirItem(List<Item> itensTarefas, Tarefa tarefa)
        {

            foreach (Item item in itensTarefas)
            {

                Console.WriteLine(item.ToString());

            }

            int numeroItem = ObterNumeroRegistro();

            foreach (Item item in itensTarefas)
            {

                if (item.numero == numeroItem)
                {

                    item.ConcluirItem();
                    tarefa.ConcluirItemTarefa();

                }
            }
            
            _notificador.ApresentarMensagem("Item editada com sucesso!", TipoMensagem.Sucesso);
        }
    }
}

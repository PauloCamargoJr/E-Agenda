using System;
using System.Collections.Generic;
using E_Agenda.ConsoleApp.Compartilhado;
using E_Agenda.ConsoleApp.ModuloItem;

namespace E_Agenda.ConsoleApp.ModuloItem
{
    public class TelaCadastroItem : TelaBase, ITelaCadastravel
    {

        private readonly RepositorioItem _repositorioItem;
        private readonly Notificador _notificador;

        public TelaCadastroItem(RepositorioItem repositorioItem, Notificador notificador) : base("Cadastro Items")
        {

            _repositorioItem = repositorioItem;
            _notificador = notificador;

        }

        public void Inserir()
        {

        }

        public void Editar()
        {
            MostrarTitulo("Editando a tarefa");

            bool temItemsCadastradas = VisualizarRegistros("Pesquisando");

            if (temItemsCadastradas == false)
            {
                _notificador.ApresentarMensagem("Nenhuma Item cadastrada para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroMedicamento = ObterNumeroRegistro();

            List<Item> itens = _repositorioItem.SelecionarTodos();

            if (itens.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhuma tarefa disponível.", TipoMensagem.Atencao);
                return;
            }

            ConcluirItem(itens);

            _notificador.ApresentarMensagem("Item editada com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            
        }



        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Items");

            List<Item> itens = _repositorioItem.SelecionarTodos();

            if (itens.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhuma tarefa disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Item item in itens)
            {

                Console.WriteLine(item.ToString());

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

                numeroRegistroEncontrado = _repositorioItem.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID da tarefa não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }

        public void ConcluirItem(List<Item> itensItems)
        {

            foreach (Item item in itensItems)
            {

                Console.WriteLine(item.ToString());

            }

            int numeroItem = ObterNumeroRegistro();

            foreach (Item item in itensItems)
            {

                if (item.numero == numeroItem)
                {

                    item.ConcluirItem();

                }
            }

            _notificador.ApresentarMensagem("TItem editada com sucesso!", TipoMensagem.Sucesso);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using E_Agenda.ConsoleApp.Compartilhado;

namespace E_Agenda.ConsoleApp.ModuloContato
{
    public class TelaCadastroContato : TelaBase, ITelaCadastravel
    {

        private readonly RepositorioContato _repositorioContato;
        private readonly Notificador _notificador;

        public TelaCadastroContato(RepositorioContato repositorioContato, Notificador notificador) : base("Cadastro Contato")
        {

            _repositorioContato = repositorioContato;
            _notificador = notificador;

        }

        public void Inserir()
        {

            MostrarTitulo("Cadastro de contato");

            Contato novaContato = ObterContato();

            _repositorioContato.Inserir(novaContato);

            _notificador.ApresentarMensagem("Contato cadastrado com sucesso!", TipoMensagem.Sucesso);

        }

        public void Editar()
        {
            MostrarTitulo("Editando o contato");

            bool temContatosCadastradas = VisualizarRegistros("Pesquisando");

            if (temContatosCadastradas == false)
            {
                _notificador.ApresentarMensagem("Nenhum Contato cadastrado para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroMedicamento = ObterNumeroRegistro();

            Contato tarefaAtualizada = ObterContato();

            bool conseguiuEditar = _repositorioContato.Editar(numeroMedicamento, tarefaAtualizada);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Contato editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Trefa");

            bool temMedicamentosRegistrados = VisualizarRegistros("Pesquisando");

            if (temMedicamentosRegistrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum Contato cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroContato = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioContato.Excluir(numeroContato);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Contato excluído com sucesso1", TipoMensagem.Sucesso);
        }

        private Contato ObterContato()
        {

            Console.WriteLine("Insira o nome do contato: ");
            string nome = Console.ReadLine();

            string email;

            do
            {

                Console.WriteLine("Insira o email do contato: ");
                email = Console.ReadLine();

                if (ValidarEmail(email))
                    break;
                else
                    _notificador.ApresentarMensagem("Email inválido!", TipoMensagem.Erro);


            } while (true);

            string telefone;

            do 
            {

                Console.WriteLine("Insira o telefone do contato: ");
                telefone = Console.ReadLine();

                if (telefone.Length == 9)
                    break;
                else
                    _notificador.ApresentarMensagem("Telefone inválido!", TipoMensagem.Erro);


            } while(true);

            Console.WriteLine("Insira empresa do contato: ");
            string empresa = Console.ReadLine();

            Console.WriteLine("Insira o cargo do contato: ");
            string cargo = Console.ReadLine();

            return new Contato(nome, email, telefone, empresa, cargo);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Contatos");

            List<Contato> contato = _repositorioContato.SelecionarTodos();

            if (contato.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum contato disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Contato tarefa in contato)
                Console.WriteLine(tarefa.ToString());

            Console.ReadLine();

            return true;
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID da contto que deseja editar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioContato.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID do contato não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }

        private bool ValidarEmail(string email)
        {

            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if(rg.IsMatch(email))
                return true;
            return false;


        }

    }
}

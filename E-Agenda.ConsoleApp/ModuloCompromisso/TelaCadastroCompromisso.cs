using System;
using System.Collections.Generic;
using E_Agenda.ConsoleApp.Compartilhado;

namespace E_Agenda.ConsoleApp.ModuloCompromisso
{
    public class TelaCadastroCompromisso : TelaBase, ITelaCadastravel
    {

        private readonly RepositorioCompromisso _repositorioCompromisso;
        private readonly Notificador _notificador;

        public TelaCadastroCompromisso(RepositorioCompromisso repositorioCompromisso, Notificador notificador) : base("Cadastro Compromisso")
        {

            _repositorioCompromisso = repositorioCompromisso;
            _notificador = notificador;

        }

        public void Inserir()
        {

            MostrarTitulo("Cadastro de compromisso");

            Compromisso novaCompromisso = ObterCompromisso();

            _repositorioCompromisso.Inserir(novaCompromisso);

            _notificador.ApresentarMensagem("Compromisso cadastrado com sucesso!", TipoMensagem.Sucesso);

        }

        public void Editar()
        {
            MostrarTitulo("Editando o compromisso");

            bool temCompromissosCadastradas = VisualizarRegistros("Pesquisando");

            if (temCompromissosCadastradas == false)
            {
                _notificador.ApresentarMensagem("Nenhum Compromisso cadastrado para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroMedicamento = ObterNumeroRegistro();

            Compromisso tarefaAtualizada = ObterCompromisso();

            bool conseguiuEditar = _repositorioCompromisso.Editar(numeroMedicamento, tarefaAtualizada);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Compromisso editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo compromisso");

            bool temMedicamentosRegistrados = VisualizarRegistros("Pesquisando");

            if (temMedicamentosRegistrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum Compromisso cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroCompromisso = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioCompromisso.Excluir(numeroCompromisso);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Compromisso excluído com sucesso1", TipoMensagem.Sucesso);
        }

        private Compromisso ObterCompromisso()
        {

            Console.WriteLine("Insira o titulo do compromisso: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Insira o assunto do compromisso: ");
            string assunto = Console.ReadLine();

            Console.WriteLine("Insira o local do compromisso: ");
            string local = Console.ReadLine();

            DateTime data = DateTime.Now;

            Console.WriteLine("Insira a hora de inicio do compromisso: ");
            int horaInicio = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insira a hora de termino do compromisso: ");
            int horaTermino = Convert.ToInt32(Console.ReadLine());

            return new Compromisso(nome, assunto, local, data, horaInicio, horaTermino);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Compromissos");

            List<Compromisso> compromisso = _repositorioCompromisso.SelecionarTodos();

            if (compromisso.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum compromisso disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Compromisso tarefa in compromisso)
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

                numeroRegistroEncontrado = _repositorioCompromisso.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID do compromisso não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }

    }
}

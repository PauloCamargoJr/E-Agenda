using System;
using System.Collections.Generic;

namespace E_Agenda.ConsoleApp.Compartilhado
{
    public class RepositorioBase<T> : IRepositorio<T> where T : EntidadeBase
    {
        protected readonly List<T> registros;

        protected int contadorNumero;

        public RepositorioBase()
        {
            registros = new List<T>();
        }

        public virtual string Inserir(T entidade)
        {
            entidade.numero = ++contadorNumero;

            registros.Add(entidade);

            return "REGISTRO_VALIDO";
        }

        public bool Editar(int idSelecionado, T novaEntidade)
        {
            foreach (T entidade in registros)
            {
                if (idSelecionado == entidade.numero)
                {
                    novaEntidade.numero = entidade.numero;

                    int posicaoParaEditar = registros.IndexOf(entidade);
                    registros[posicaoParaEditar] = novaEntidade;

                    return true;
                }
            }

            return false;
        }

        public bool Editar(Predicate<T> condicao, T novaEntidade)
        {
            foreach (T entidade in registros)
            {
                if (condicao(entidade))
                {
                    novaEntidade.numero = entidade.numero;

                    int posicaoParaEditar = registros.IndexOf(entidade);
                    registros[posicaoParaEditar] = novaEntidade;

                    return true;
                }
            }

            return false;
        }

        public bool Excluir(int idSelecionado)
        {
            foreach (T entidade in registros)
            {
                if (idSelecionado == entidade.numero)
                {
                    registros.Remove(entidade);
                    return true;
                }
            }
            return false;
        }

        public bool Excluir(Predicate<T> condicao)
        {
            foreach (T entidade in registros)
            {
                if (condicao(entidade))
                {
                    registros.Remove(entidade);
                    return true;
                }
            }
            return false;
        }

        public T SelecionarRegistro(int idSelecionado)
        {
            foreach (T entidade in registros)
            {
                if (idSelecionado == entidade.numero)
                    return entidade;
            }

            return null;
        }

        public T SelecionarRegistro(Predicate<T> condicao)
        {
            foreach (T entidade in registros)
            {
                if (condicao(entidade))
                    return entidade;
            }

            return null;
        }

        public List<T> SelecionarTodos()
        {
            return registros;
        }

        public List<T> Filtrar(Predicate<T> condicao)
        {
            List<T> registrosFiltrados = new List<T>();

            foreach (T registro in registros)
                if (condicao(registro))
                    registrosFiltrados.Add(registro);

            return registrosFiltrados;
        }

        public bool ExisteRegistro(int idSelecionado)
        {
            foreach (T entidade in registros)
                if (idSelecionado == entidade.numero)
                    return true;

            return false;
        }

        public bool ExisteRegistro(Predicate<T> condicao)
        {
            foreach (T entidade in registros)
                if (condicao(entidade))
                    return true;

            return false;
        }
    }
}

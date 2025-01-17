﻿using System;
using System.Collections.Generic;

namespace E_Agenda.ConsoleApp.Compartilhado
{
    public interface IRepositorio<T> where T : EntidadeBase
    {
        string Inserir(T entidade);
        bool Editar(int idSelecionado, T novaEntidade);
        bool Excluir(int idSelecionado);
        bool ExisteRegistro(int idSelecionado);
        T SelecionarRegistro(int idSelecionado);
        List<T> Filtrar(Predicate<T> condicao);
        List<T> SelecionarTodos();

    }
}

﻿using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRepository<T>: IDisposable where T : Entity
    {
        Task Adicionar(T entity);
        Task<T?> ObterPorId(Guid id);
        Task<List<T>> ObterTodos();
        Task Atualizar(T entity);
        Task Remover(Guid id);
        Task<IEnumerable<T?>> Buscar(Expression<Func<T, bool>> predicate);
        Task<int> SaveChanges();
    }
}

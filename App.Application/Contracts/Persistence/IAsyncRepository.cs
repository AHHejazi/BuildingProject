﻿using Framework.Core.ListManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.App.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Expression<Func<T, bool>> condtion);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);//ask
        Task DeleteAsync(object entityId);
        Task<T> GetByIdAsync(object id);

        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);

        Task<T> GenerateModelNumber(Expression<Func<T, bool>> condtion, Expression<Func<T, string>> orderBy);


    }
}

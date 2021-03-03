﻿
using Application.App.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly BuildingDbContext _dbContext;

        public BaseRepository(BuildingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public virtual async Task<T> GetByIdAsync(Guid id)
        //{
        //    return await _dbContext.Set<T>().FindAsync(id);
        //}

        //public async Task<IReadOnlyList<T>> ListAllAsync()
        //{
        //    return await _dbContext.Set<T>().ToListAsync();
        //}

        //public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        //{
        //    return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        //}

        //public async Task<T> AddAsync(T entity)
        //{
        //    await _dbContext.Set<T>().AddAsync(entity);
        //    await _dbContext.SaveChangesAsync();

        //    return entity;
        //}

        //public async Task UpdateAsync(T entity)
        //{
        //    _dbContext.Entry(entity).State = EntityState.Modified;
        //    await _dbContext.SaveChangesAsync();
        //}

        public async Task DeleteAsync(object entityId)
        {
            var entity = await GetByIdAsync(entityId);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        //public Task DeleteAsync(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }


        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
             await _dbContext.SaveChangesAsync();
        }

        //public Task DeleteAsync(T entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

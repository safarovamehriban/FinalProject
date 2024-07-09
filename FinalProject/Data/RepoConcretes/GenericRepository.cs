﻿using Core.Models;
using Core.RepoAbstract;
using Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.RepoConcretes
{

    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        AppDbContext _appDbContext;
        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
        }

        public int Commit()
        {
            return _appDbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
        }


        public T Get(Func<T, bool>? func = null)
        {
            return func == null ?  
                _appDbContext.Set<T>().FirstOrDefault() : 
                _appDbContext.Set<T>().FirstOrDefault(func);
        }



        public List<T> GetAll(Func<T, bool>? func = null)
        {
            return func == null ?  
                _appDbContext.Set<T>().ToList() :  
                _appDbContext.Set<T>().Where(func).ToList();
        }

    }
}


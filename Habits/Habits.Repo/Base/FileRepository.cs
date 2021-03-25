using Habits.Data.Base;
using Habits.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habits.Repo.Base
{
    public class FileRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected Dictionary<long, T> _entities;
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            _entities.Add(entity.Id, entity);
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            _entities[entity.Id] = entity;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericRepositoryExample
{
    public class GenericRepository<T> : IRepository<T> where T : Entity
    {
        private readonly List<T> _items;

        public GenericRepository()
        {
            _items = new List<T>();
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public void Save()
        {
            // In a real implementation, this method would persist changes to the data source.
            // For this example, it does nothing since we're using an in-memory list.
        }

        public IEnumerable<T> GetAll()
        {
            return _items;
        }

        public T GetById(int id)
        {
            return _items.FirstOrDefault(item => item.Id == id);
        }
    }
}

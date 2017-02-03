// -----------------------------------------------------------------------
// <copyright file="MemoryRepository.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------
namespace Api.test.Business.DataAccess
{
    using System;
    using System.Collections.Generic;

    public class MemoryRepository<T> : IRepository<T>
        where T : IEntity
    {
        private readonly Dictionary<string, T> repository = new Dictionary<string, T>();
        
        public T GetById(string id)
        {
            T value;
            this.repository.TryGetValue(id, out value);
            return value;
        }

        public void Add(T value)
        {
            this.repository.Add(value.Id, value);
        }

        public bool TryAdd(T value)
        {
            if (value.Id != null)
            {
                return false;
            }
            
            value.Id = this.GetUniqueId(); 
            this.repository.Add(value.Id, value);

            return true;
        }

        private string GetUniqueId()
        {
            while (true)
            {
                Guid guid = Guid.NewGuid();
                if (this.repository.ContainsKey(guid.ToString()))
                {
                    continue;
                }

                return guid.ToString();
                break;
            }
        }
    }
}
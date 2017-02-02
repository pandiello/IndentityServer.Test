// -----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------
namespace Api.test.Business.DataAccess
{
    public interface IRepository<T>
    {
        T GetById(string id);

        void Add(T value);

        bool TryAdd(T value);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Entities;

namespace Data.Interfaces
{
    public interface IRepository<T> where T: IEntity,new()
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(Guid id);
        Task<Guid> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);
        Task<bool> IsExist(Guid id);
    }
}
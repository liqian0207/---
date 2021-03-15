using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService
{
    public interface IBaseService<TEntity> where TEntity : class, new()
    {
        Task<bool> Add(TEntity entity);
        Task<bool> Delete(int id);
        Task<bool> Edit(TEntity entity);
        Task<TEntity> Find(int id);
    }
}

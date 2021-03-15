using IRepository;
using IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        //从子类构造函数中传入
        protected IBaseRepository<TEntity> _BaseRepository;
        public async Task<bool> Add(TEntity entity)
        {
            return await _BaseRepository.Add(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _BaseRepository.Delete(id);
        }

        public async Task<bool> Edit(TEntity entity)
        {
            return await _BaseRepository.Edit(entity);
        }

        //
        public async Task<TEntity> Find(int id)
        {
            //用户数据总不能把密码返回到前端吧
            //dto导航查
            return await _BaseRepository.Find(id);
        }
    }
}

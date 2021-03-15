using IRepository;
using Model.Models;
using SqlSugar;
using SqlSugar.IOC;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository<TEntity> : SimpleClient<TEntity>,IBaseRepository<TEntity> where TEntity:class,new()
    {
        //默认等于null
        public BaseRepository(ISqlSugarClient context=null):base(context)
        {
            //start.up中已经注入，在这里使用
            base.Context = DbScoped.Sugar;
            #region  创建数据库和创建表
            ////创建数据库
            //base.Context.DbMaintenance.CreateDatabase();
            
            ////创建表
            //base.Context.CodeFirst.InitTables(
            //    //想创建的表都写这里
            //    typeof(PeCustomer),
            //    typeof(PeExChestXRay)
            //    );
            #endregion
        }
        //一些异步u方法，已经封装好了，爽！！
        //虚方法子类想导航查询，重写这个方法即可
        //可不加virual
        public virtual async Task<bool> Add(TEntity entity)
        {
            return await base.InsertAsync(entity);
        }

        public virtual async Task<bool> Delete(int id)
        {
            return await base.DeleteByIdAsync(id);
        }

        
        public virtual async Task<TEntity> Find(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public virtual async Task<bool> Edit(TEntity entity)
        {
            return await base.UpdateAsync(entity);
        }
    }
}

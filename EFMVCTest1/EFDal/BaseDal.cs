using EFModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFDal
{
  public abstract partial  class BaseDal<T>
        where T:class
    {
        DbContext dbContext = new MyContext();
        /// <summary>
        /// 根据分页获取数据
        /// </summary>
        /// <param name="pageSize">每页大小</param>
        /// <param name="PageIndex">当前页</param>
        /// <returns></returns>
        public IQueryable<T> GetList(int pageSize,int PageIndex)
        {
          return  dbContext.Set<T>().OrderByDescending(GetKey()).Skip((PageIndex - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// 根据id返回一行数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetOneList(int id)
        {
           return dbContext.Set<T>().Where(GetWhere(id)).FirstOrDefault();
        }

        /// <summary>
        /// 根据对象添加数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(T t)
        {
            dbContext.Set<T>().Add(t);
            return dbContext.SaveChanges();
        }

        /// <summary>
        /// 根据id删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Remove(int id)
        {
            var t = GetOneList(id);
            dbContext.Set<T>().Remove(t);
            return dbContext.SaveChanges();
        }

        /// <summary>
        /// 根据实体对象修改数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Edit(T t)
        {
            dbContext.Set<T>().Attach(t);//首先绑定实体
            dbContext.Entry(t).State = EntityState.Modified;//将实体设置为修改
            return dbContext.SaveChanges();
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns></returns>
        public int PageCount()
        {
          return  dbContext.Set<T>().Count();
        }


        public abstract Expression<Func<T, int>> GetKey();

        public abstract Expression<Func<T, bool>> GetWhere(int id);
    }
}

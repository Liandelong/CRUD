using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFModel;
using EFDal;
namespace EFBll
{
  public abstract partial  class BaseBll<T> where T:class
    {
        private BaseDal<T> dal;
        public abstract BaseDal<T> GetBaseDal();
        public BaseBll()
        {
            dal = GetBaseDal();
        }

        /// <summary>
        /// 根据分页查询数据
        /// </summary>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页</param>
        /// <returns></returns>
        public IQueryable<T> GetList(int pageSize,int pageIndex)
        {
            return dal.GetList(pageSize, pageIndex);
        }


        /// <summary>
        /// 根据id查单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetOneList(int id)
        {
            return dal.GetOneList(id);
        }

        /// <summary>
        /// 根据对象增加数据返回bool
        /// </summary>
        /// <param name="t">对象</param>
        /// <returns></returns>
        public bool Add(T t)
        {
            return dal.Add(t)>0;
        }

        /// <summary>
        /// 根据id删除数返回bool
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remove(int id)
        {
            return dal.Remove(id) > 0;
        }

        /// <summary>
        /// 根据对象修改数据
        /// </summary>
        /// <param name="t">对象</param>
        /// <returns></returns>
        public bool Edit(T t)
        {
            return dal.Edit(t) > 0;
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns></returns>
        public int PageCount()
        {
            return dal.PageCount();
        }
    }
}

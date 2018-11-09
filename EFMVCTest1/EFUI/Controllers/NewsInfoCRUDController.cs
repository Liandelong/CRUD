using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFBll;
using EFModel;
using System.Text;
namespace EFUI.Controllers
{

    public class NewsInfoCRUDController : Controller
    {
        BaseBll<NewsInfo> newsInfoBll = new NewsInfoBll();//创建NewsInfoBll()等于创建BaseBll<NewsInfo>
        BaseBll<TypeInfo> typeInfoBll = new TypeInfoBll();
        // GET: NewsInfoCRUD
        //查询
        public ActionResult Index()
        {
            //ViewData.Model = newsInfoBll.GetList(10,1);
            return View();
        }

        public ActionResult LoadList(int pageSize,int pageIndex)//根据异步分页
        {
            var list = newsInfoBll.GetList(pageSize, pageIndex)
                .Select(u=>new {//避开导航属性
                    NewsId=u.NewsId,
                    NewsConent= u.NewsConent,
                    RegTime=u.RegTime,
                    TypeConent=u.TypeInfo.TypeConent
                })
                .ToList();
            int Count = newsInfoBll.PageCount();//获取总条数
            int pageCount = Convert.ToInt32(Math.Ceiling(Count * 1.0 / pageSize));//获取总页数

            StringBuilder pager = new StringBuilder();
            if (pageIndex == 1)
            {
                pager.Append("首页 上一页");
            }
            else
            {
                pager.Append("<a href='javascript:GoPage(1)'>首页</a>&nbsp;<a href='javascript:GoPage(" + (pageIndex - 1) +
                             ")'>上一页</a>");
            }

            if (pageIndex == pageCount)
            {
                pager.Append("下一页 末页");
            }
            else
            {
                pager.Append("<a href='javascript:GoPage(" + (pageIndex + 1) +
                             ")'>下一页</a>&nbsp;<a href='javascript:GoPage(" + pageCount +
                             ")'>末页</a>");
            }
            var temp = new
            {
                page = pager.ToString(),
                list = list
            };
            return Json(temp,JsonRequestBehavior.AllowGet);
        }


        //添加
        public ActionResult Add()
        {
           var list1= typeInfoBll.GetList(10, 1);
           List<SelectListItem> list = new List<SelectListItem>();
            foreach (TypeInfo item in list1)
            {
                list.Add(new SelectListItem//初始化SelectListItem 填充List
                {
                    Text = item.TypeConent,
                    Value = item.TypeId.ToString()
                });
            }
            ViewBag.TypeList = list;
            return View();
        }

        [HttpPost]
        public ActionResult Add(NewsInfo newsInfo)
        {
            
            newsInfo.RegTime = DateTime.Now;
            newsInfoBll.Add(newsInfo);//添加数据
            return Redirect(Url.Action("Index"));         
        }


        public ActionResult Edit(int id)
        {

            ViewData.Model = newsInfoBll.GetOneList(id);
            var list1 = typeInfoBll.GetList(10, 1);
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (TypeInfo item in list1)
            {
                if(newsInfoBll.GetOneList(id).TypeInfo.TypeConent==item.TypeConent)
                {
                    list.Add(new SelectListItem//初始化SelectListItem 填充List
                    {
                        Text = item.TypeConent,
                        Value = item.TypeId.ToString(),
                        Selected=true
                    });
                }
                else
                {
                    list.Add(new SelectListItem//初始化SelectListItem 填充List
                    {
                        Text = item.TypeConent,
                        Value = item.TypeId.ToString()
                    });
                }
               
            }
            ViewBag.TypeList = list;

            return View();
        }

        [HttpPost]
        public ActionResult Edit(NewsInfo newsInfo)
        {
            newsInfoBll.Edit(newsInfo);
            return Redirect(Url.Action("Index"));
        }

        public ActionResult Remove(int id)
        {
            newsInfoBll.Remove(id);
            return Redirect(Url.Action("Index"));
        }
    }
}
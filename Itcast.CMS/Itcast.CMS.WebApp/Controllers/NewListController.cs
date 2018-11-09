using Itcast.CMS.Model;
using Itcast.CMS.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Itcast.CMS.WebApp.Controllers
{
    public class NewListController : Controller
    {
        //
        // GET: /NewList/
        BLL.NewInfoService NewInfoService = new BLL.NewInfoService();
        BLL.NewCommentService NewCommentService = new BLL.NewCommentService();
        public ActionResult Index()
        {
            int pageIndex = Request["pageIndex"] != null ? Convert.ToInt32(Request["pageIndex"]) : 1;
            int pageSize = 5;
            int pageCount = NewInfoService.GetPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            List<T_New> list = NewInfoService.GetPageEntityList(pageIndex, pageSize);
            ViewData["newInfoList"] = list;
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageCount"] = pageCount;
            return View();
        }
        public ActionResult ShowDetail()
        {
            int id = int.Parse(Request["id"]);
            T_New NewInfo=NewInfoService.GetModel(id);
            ViewData.Model = NewInfo;
            return View();
        }
        public ActionResult AddComment()
        {
            int id = int.Parse(Request["id"]);
            string msg = Request["msg"];
            T_NewComment comment = new T_NewComment();
            comment.Msg = msg;
            comment.NewId = id;
            comment.CreateDateTime = DateTime.Now;
            if (NewCommentService.InsertEntityModel(comment))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        public ActionResult LoadComment()
        {
            int id = int.Parse(Request["id"]);
           List<T_NewComment>list=NewCommentService.GetNewCommentList(id);
           List<CommentViewModel> newList = new List<CommentViewModel>();
           foreach (var commentInfo in list)
           {
               CommentViewModel viewModel = new CommentViewModel();
               TimeSpan timeSpan=DateTime.Now-commentInfo.CreateDateTime;
               viewModel.CreateDateTime = Common.WebCommon.GetTimeSpan(timeSpan);
               viewModel.Msg = commentInfo.Msg;
               newList.Add(viewModel);
           }
           return Json(newList, JsonRequestBehavior.AllowGet);
        }
    }
}

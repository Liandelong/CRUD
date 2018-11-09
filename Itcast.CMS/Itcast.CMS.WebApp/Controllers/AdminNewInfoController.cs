using Itcast.CMS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Itcast.CMS.WebApp.Controllers
{
    public class AdminNewInfoController : Controller
    {
        //
        // GET: /AdminNewInfo/
        BLL.NewInfoService NewInfoService = new BLL.NewInfoService();
        #region 分页列表展示
          public ActionResult Index()
        {
            int pageIndex = Request["pageIndex"] != null ? Convert.ToInt32(Request["pageIndex"]) : 1;
            int pageSize = 5;
            int pageCount = NewInfoService.GetPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            List<T_New>list=NewInfoService.GetPageEntityList(pageIndex, pageSize);
            ViewData["newInfoList"] = list;
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageCount"] = pageCount;
            return View();
        }
        #endregion

       #region 显示详细信息
             public ActionResult GetNewInfoModel()
        {
            int id = int.Parse(Request["id"]);
           T_New newInfo= NewInfoService.GetModel(id);
           return Json(newInfo,JsonRequestBehavior.AllowGet);
        }
          #endregion

        #region 删除数据
             public ActionResult DeleteNewInfo()
        {
            int id = int.Parse(Request["id"]);
            bool b = NewInfoService.DeleteEntityModel(id);
            if (b)
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
             #endregion

        #region 添加信息
             public ActionResult ShowAddInfo()
             {
                 return View();
             }
                [ValidateInput(false)]
             public ActionResult AddNewInfo(T_New newInfo)
             {
                 //注意Upload：目录是编辑器的目录要加上，还要添加LitJson，然后生成一下
                 newInfo.SubDateTime = DateTime.Now;
                 newInfo.Msg = Request["Msg"];
                 if (NewInfoService.InsertEntityModel(newInfo))
                 {


                     return Json(newInfo,JsonRequestBehavior.AllowGet);
                 }
                 else
                 {
                     return Content("no:添加失败");
                 }
             }
        #endregion

        #region 上传图片
             public ActionResult FileUpload()
             {
                HttpPostedFileBase file= Request.Files["MenuIcon"];
                if (file == null)
                {
                    return Content("no:上传文件不能为空!");
                }
                else
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string fileExt = Path.GetExtension(fileName);
                    if (fileExt == ".jpg")
                    {
                        string dir = "/FileUploadImage/"+DateTime.Now.Year+"/"+DateTime.Now.Month+"/"+DateTime.Now.Day+"/";
                        Directory.CreateDirectory(Path.GetDirectoryName(Request.MapPath(dir)));
                        string newfileName=Guid.NewGuid().ToString();
                        string fullDir = dir + newfileName + fileExt;
                        file.SaveAs(Request.MapPath(fullDir));
                        return Content("ok:"+fullDir);
                    }
                    else
                    {
                        return Content("no:上传文件格式错误!!");
                    }
                }
             }
        #endregion

        #region 展示要修改的数据
             public ActionResult ShowEdit()
             {
                 int id = int.Parse(Request["id"]);
                T_New newInfo=NewInfoService.GetModel(id);
                ViewData.Model = newInfo;
                return View();
             }
         
        #endregion

        #region 完成信息修改
             public ActionResult EditNewInfo(T_New newInfo)
             {
                 if (NewInfoService.UpdateEntityModel(newInfo))
                 {
                     return Content("ok");
                 }
                 else
                 {
                     return Content("no");

                 }
             }
        #endregion
        

    }
}

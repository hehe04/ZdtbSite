using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;
using Admin = ZdtbSite.Web.Areas.ZdtbAdmin.Models;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    public class NewsCrawlerController : BaseController
    {
        public static string CurrentPath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data\\NewCrawler\\");
            }
        }
        public static string CurrentFile
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data\\NewCrawler\\Updated.log");
            }
        }


        private string CurrentUrl { get { return Url.Action("Index"); } }
        private IRepository<ContentType> contentTypeRepository = null;
        private IRepository<Article> articleRepository = null;
        private IUnitOfWork unitofWork = null;

        public NewsCrawlerController(
            IRepository<ContentType> contentTypeRepository,
            IRepository<Article> articleRepository,
            IUnitOfWork unitofWork)
        {
            this.articleRepository = articleRepository;
            this.unitofWork = unitofWork;
            this.contentTypeRepository = contentTypeRepository;
        }
        // GET: ZdtbAdmin/NewsCrawler
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            Page page = new Page(pageIndex, pageSize);
            var list = articleRepository.GetPage(page, e => e.OriginArticlesType == OriginArticlesType.Web, e => e.Id);
            var types = AutoMapper.Mapper.Map<List<ContentType>, List<Admin.ContentTypeViewModel>>(contentTypeRepository.GetAll().ToList());
            //ViewData["ContentTypes"] = types;
            return View(list);
        }

        public ActionResult Crawler()
        {
            WebClient client = new WebClient();
            Regex regexurl = new Regex("<a href=\"(http://ayerstransformers\\.com/\\?p=\\d+)\">(.+)</a>");
            Regex regexcontent = new Regex("<article class=\"entry post clearfix\">[\\w\\s.\\W]+</article>");
            Models.ResponseModel responsemodel = new Admin.ResponseModel();
            if (!Directory.Exists(CurrentPath))
            {
                Directory.CreateDirectory(CurrentPath);
            }
            if (!System.IO.File.Exists(CurrentFile))
            {
                System.IO.File.Create(CurrentFile).Close();
            }
            string content = string.Empty;
            try
            {
                content = client.DownloadString("http://ayerstransformers.com/?cat=1");
            }
            catch (Exception ex)
            {
                responsemodel.Success = false;
                responsemodel.Msg = ex.Message;
                return Json(responsemodel, JsonRequestBehavior.AllowGet);
            }
            MatchCollection collection = regexurl.Matches(content);
            List<string> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(System.IO.File.ReadAllText(CurrentFile));
            if (list == null)
            {
                list = new List<string>();
            }
            bool isCommit = false;
            foreach (Match item in collection)
            {
                if (!list.Contains(item.Groups[1].Value))
                {
                    try
                    {
                        Article model = new Article();
                        model.IsPublish = false;
                        model.OriginArticlesType = OriginArticlesType.Web;
                        model.UpdateDateTime = DateTime.Now;
                        model.PublisherDateTime = DateTime.Now;
                        model.Title = item.Groups[2].Value;
                        model.Tag = item.Groups[2].Value;
                        model.ContentTyepId = 2;
                        content = client.DownloadString(item.Groups[1].Value);
                        model.Content = regexcontent.Match(content).Groups[0].Value;
                        articleRepository.Add(model);
                        list.Add(item.Groups[1].Value);
                        isCommit = true;
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            responsemodel.Success = true;
            responsemodel.RedirectUrl = CurrentUrl;
            responsemodel.Msg = "抓取新闻成功，无更新";
            if (isCommit)
            {
                unitofWork.Commit();
                responsemodel.Msg = "抓取新闻成功，有更新";
            }
            System.IO.File.WriteAllText(CurrentFile, Newtonsoft.Json.JsonConvert.SerializeObject(list));
            return Json(responsemodel, JsonRequestBehavior.AllowGet);
        }
    }
}
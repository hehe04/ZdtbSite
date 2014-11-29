using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin = ZdtbSite.Web.Areas.ZdtbAdmin.Models;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;
using System.Linq.Expressions;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    //取消html标签提交验证
    [ValidateInput(false)]
    public class ArticleController : BaseController
    {
        private string CurrentUrl
        {
            get
            {
                return Url.Action("Index", "Article");
            }
        }

        private IRepository<ContentType> contentTypeRepository = null;
        private IRepository<Article> articleRepository = null;
        private IUnitOfWork unitofWork = null;

        public ArticleController(
            IRepository<ContentType> contentTypeRepository,
            IRepository<Article> articleRepository,
            IUnitOfWork unitofWork)
        {
            this.contentTypeRepository = contentTypeRepository;
            this.articleRepository = articleRepository;
            this.unitofWork = unitofWork;
        }

        [HttpGet]
        // GET: ZdtbAdmin/Article
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            Page page = new Page(pageIndex, pageSize);
            Expression<Func<Article, bool>> where = e => true;
            string search = Request.Cookies["searchContentTypeId"] == null ? "-1" : Request.Cookies["searchContentTypeId"].Value;
            int ContentTypeId;
            if (!int.TryParse(search, out ContentTypeId))
            {
                ContentTypeId = -1;
            }
            if (ContentTypeId != -1)
            {
                where = e => e.ContentTyepId == ContentTypeId;
            }
            var list = articleRepository.GetPage(page, where, e => e.Id);
            var types = AutoMapper.Mapper.Map<List<ContentType>, List<Admin.ContentTypeViewModel>>(contentTypeRepository.GetAll().ToList());
            ViewBag.ContentTypes = types;
            return View(list);
        }

        [HttpPost]
        public ActionResult Index(int ContentTypeId = -1)
        {
            Page page = new Page(1, 10);
            Expression<Func<Article, bool>> where = e => true;
            HttpCookie cookie = new HttpCookie("searchContentTypeId");
            cookie.Value = ContentTypeId.ToString();
            Response.SetCookie(cookie);
            if (ContentTypeId != -1)
            {
                where = e => e.ContentTyepId == ContentTypeId;
            }
            var list = articleRepository.GetPage(page, where, e => e.Id);
            var types = AutoMapper.Mapper.Map<List<ContentType>, List<Admin.ContentTypeViewModel>>(contentTypeRepository.GetAll().ToList());
            ViewBag.ContentTypes = types;
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            Admin.ArticleDataViewModel model = new Admin.ArticleDataViewModel();
            var contentTypes = contentTypeRepository.GetAll().ToList();
            model.ContentTypes = AutoMapper.Mapper.Map<List<ContentType>, List<Admin.ContentTypeViewModel>>(contentTypes);
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Admin.ArticleDataViewModel viewModel, [Bind(Prefix = "Article")]int? ContentTyep)
        {
            Admin.ResponseModel responseModel = new Admin.ResponseModel();
            if (ContentTyep == null)
            {
                ContentTyep = int.Parse(Request.Form["Article.ContentTyep"]);
            }
            Article model = AutoMapper.Mapper.Map<Admin.ArticleViewModel, Article>(viewModel.Article);
            if (model.IsPublish)
            {
                model.Publisher = LoginUserName;
                model.PublisherDateTime = DateTime.Now;
            }
            model.OriginArticlesType = OriginArticlesType.User;
            model.UpdateDateTime = DateTime.Now;
            model.ContentType = contentTypeRepository.GetById(ContentTyep.Value);
            articleRepository.Add(model);
            unitofWork.Commit();
            responseModel.Success = true;
            responseModel.Msg = "成功添加文章，页面即将跳转";
            responseModel.RedirectUrl = CurrentUrl;
            return Json(responseModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Modify(int id)
        {
            Admin.ArticleDataViewModel model = new Admin.ArticleDataViewModel();
            var contentTypes = contentTypeRepository.GetAll().ToList();
            var currentArticle = articleRepository.GetById(id);
            model.ContentTypes = AutoMapper.Mapper.Map<List<ContentType>, List<Admin.ContentTypeViewModel>>(contentTypes);
            model.Article = AutoMapper.Mapper.Map<Article, Admin.ArticleViewModel>(currentArticle);
            return View(model);
        }

        [HttpPost]
        public ActionResult Modify(Admin.ArticleDataViewModel viewModel)
        {
            Admin.ResponseModel responseModel = new Admin.ResponseModel();

            Article model = AutoMapper.Mapper.Map<Admin.ArticleViewModel, Article>(viewModel.Article);
            model.OriginArticlesType = OriginArticlesType.User;
            model.UpdateDateTime = DateTime.Now;
            articleRepository.Update(model);
            unitofWork.Commit();
            responseModel.Success = true;
            responseModel.Msg = "成功修改文章，页面即将跳转";
            responseModel.RedirectUrl = CurrentUrl;
            return Json(responseModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Publish(int id, string url)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();

            var article = articleRepository.GetById(id);
            article.IsPublish = true;
            article.Publisher = LoginUserName;
            article.PublisherDateTime = DateTime.Now;
            articleRepository.Update(article);
            unitofWork.Commit();
            model.Success = true;
            model.Msg = "成功发布文章";
            model.RedirectUrl = url;
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Delete(int id, string url)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();

            articleRepository.Delete(articleRepository.GetById(id));
            unitofWork.Commit();
            model.Success = true;
            model.Msg = "成功删除文章";
            model.RedirectUrl = url;
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
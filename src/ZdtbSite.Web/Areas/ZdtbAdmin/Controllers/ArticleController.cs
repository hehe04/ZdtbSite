using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin = ZdtbSite.Web.Areas.ZdtbAdmin.Models;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    //取消html标签提交验证
    [ValidateInput(false)]
    public class ArticleController : BaseController
    {
        private string CurrentUrl { get { return Url.Action("Index", "Article"); } }

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

        // GET: ZdtbAdmin/Article
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            Page page = new Page(pageIndex, pageSize);
            var list = articleRepository.GetPage(page, e => true, e => e.Id);
            var types = AutoMapper.Mapper.Map<List<ContentType>,List<Admin.ContentTypeViewModel>>(contentTypeRepository.GetAll().ToList());
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
            model.ContentTyep = contentTypeRepository.GetById(ContentTyep.Value);
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
        public ActionResult Modify(Admin.ArticleDataViewModel viewModel, [Bind(Prefix = "Article")]int? ContentTyep)
        {
            Admin.ResponseModel responseModel = new Admin.ResponseModel();
            if (ContentTyep == null)
            {
                ContentTyep = int.Parse(Request.Form["Article.ContentTyep"]);
            }
            Article model = AutoMapper.Mapper.Map<Admin.ArticleViewModel, Article>(viewModel.Article);
            model.OriginArticlesType = OriginArticlesType.User;
            model.UpdateDateTime = DateTime.Now;
            model.ContentTyep = contentTypeRepository.GetById(ContentTyep.Value);
            //model.ContentTyep = ContentTyep.Value;
            articleRepository.Update(model);
            unitofWork.Commit();
            responseModel.Success = true;
            responseModel.Msg = "成功修改文章，页面即将跳转";
            responseModel.RedirectUrl = CurrentUrl;
            return Json(responseModel, JsonRequestBehavior.AllowGet);
        }
    }
}
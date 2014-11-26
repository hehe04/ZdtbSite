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
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            Admin.ArticleDataViewModel model = new Admin.ArticleDataViewModel();
            var contentTypes = contentTypeRepository.GetAll().ToList();
            model.ContentTypes = AutoMapper.Mapper.Map<List<ContentType>, List<Admin.ContentTypeViewModel>>(contentTypes);
            return View(model);
        }

        //取消html标签提交验证
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Add(Admin.ArticleDataViewModel viewModel, [Bind(Prefix = "Article")]int? ContentTyep)
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
            articleRepository.Add(model);
            unitofWork.Commit();
            responseModel.Success = true;
            responseModel.Msg = "成功添加文章，页面即将跳转";
            responseModel.RedirectUrl = CurrentUrl;
            return Json(responseModel, JsonRequestBehavior.AllowGet);
        }
    }
}
using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;
using Admin = ZdtbSite.Web.Areas.ZdtbAdmin.Models;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    [ValidateInput(false)]
    [Authorize(Users = "")]
    public class ProductController : BaseController
    {
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<ProductType> productTypeRepository;
        private IUnitOfWork unitOfWork;
        private string CurrentUrl { get { return Url.Action("Index", "Product"); } }

        public ProductController(IRepository<Product> productRepository, IRepository<ProductType> productTypeRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.productTypeRepository = productTypeRepository;
            this.unitOfWork = unitOfWork;
        }
        // GET: ZdtbAdmin/Product
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            Page page = new Page(pageIndex, pageSize);
            IPagedList<Product> pageList = productRepository.GetPage(page, e => true, e => e.Id);
            return View(pageList);
        }

        public ActionResult Add()
        {
            Admin.ProductViewModel model = new Admin.ProductViewModel();
            var list = productRepository.GetAll().ToList();
            ViewBag.DropDownListResult = new ProductTypeController(productTypeRepository, unitOfWork).GetDownList(0, productTypeRepository.GetAll().ToList());
            return View(model);
        }

        public void GetImageUrl(HttpPostedFileBase hpFill, ref string MaxImgURL, ref string MiniImgURL)
        {
            if (hpFill.ContentType.IndexOf("image") > -1)
            {
                //得到上传的图片名 hpFill.FileName得到客户端上传文件的路劲
                string fillName = System.IO.Path.GetFileName(hpFill.FileName);
                //获取保存路径
                string filePath = HttpContext.Server.MapPath("/Images/uploadImages/");
                //判断路径是否存 创建路径
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string guid = Guid.NewGuid().ToString();
                //保存大图
                MaxImgURL = filePath + guid + "_Max_" + fillName;
                hpFill.SaveAs(MaxImgURL);

                //从上传的流中拿出图片
                using (Image img = Image.FromStream(hpFill.InputStream))
                {
                    //创建要修改后的图片的大小缩小原来的5倍
                    using (Bitmap bit = new Bitmap(img.Width / 8, img.Height / 8))
                    {
                        using (Graphics g = Graphics.FromImage(bit))
                        {
                            //缩略图,第一个Rectangle是你要缩略过后的图片大小（要把原图画成多大）,第二个Rectangle是要从img对象中的那个坐标开始绘制，所绘制的宽度和长度是多少，最后是以像素的形式
                            g.DrawImage(img, new Rectangle(0, 0, bit.Width, bit.Height), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                            //将绘制好的小图保存到指定的路径中
                            MiniImgURL = filePath + guid + "_Mini_" + fillName;
                            bit.Save(MiniImgURL);
                        }
                    }
                }
            }

        }

        [HttpPost]
        public ActionResult Add(Admin.ProductViewModel viewmodel, HttpPostedFileBase fileElem)
        {
            string maxUrl = null, minUrl = null;
            if (Request.Files.Count == 1) GetImageUrl(fileElem, ref maxUrl, ref minUrl);
            Admin.ResponseModel responseModel = new Admin.ResponseModel();
            try
            {
                var ProductModel = AutoMapper.Mapper.Map<Admin.ProductViewModel, Model.Product>(viewmodel);
                ProductModel.CreateTime = DateTime.Now;
                ProductModel.ImageUrl = maxUrl;
                ProductModel.ThumbnailUrl = minUrl;
                //ProductModel.ProductType = productTypeRepository.GetById(viewmodel.ProductTypeId);
                productRepository.Add(ProductModel);
                unitOfWork.Commit();
                responseModel.Success = true;
                responseModel.Msg = "添加产品成功，页面即将跳转到产品列表页";
                responseModel.RedirectUrl = Url.Action("Index");
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Msg = "添加产品失败，请重试" + ex.Message;
            }
            return Json(responseModel);
        }


        [HttpGet]
        public ActionResult Modify(int id)
        {
            Product ProductInfo = productRepository.GetById(id);            
            Admin.ProductViewModel model = AutoMapper.Mapper.Map<Model.Product, Admin.ProductViewModel>(ProductInfo);
            if (model.ImageUrl != null)
            {
                //绝对路径转成相对路径
                string tmpRootDir = Server.MapPath(Request.ApplicationPath.ToString());//获取程序根目录
                string imagesurl2 = ProductInfo.ImageUrl.Replace(tmpRootDir, ""); //转换成相对路径
                imagesurl2 = imagesurl2.Replace(@"\", @"/");
                model.showImageUrl= "/" + imagesurl2;
            }

            var list = productTypeRepository.GetAll().ToList();
            ViewBag.DropDownListResult = new ProductTypeController(productTypeRepository, unitOfWork).GetDownList(0, list);
            return View(model);
        }

        [HttpPost]
        public ActionResult Modify(Admin.ProductViewModel viewmodel, HttpPostedFileBase fileElem)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();
            try
            {
                if (Request.Files.Count == 1)
                {
                    string maxUrl = null, miniUrl = null;
                    GetImageUrl(fileElem, ref maxUrl, ref miniUrl);
                    viewmodel.ImageUrl = maxUrl;
                    viewmodel.ThumbnailUrl = miniUrl;
                }
                viewmodel.CreateTime = DateTime.Now;
                //viewmodel.ProductType = productTypeRepository.GetById(viewmodel.ProductTypeId);
                var ProductInfo = AutoMapper.Mapper.Map<Admin.ProductViewModel, Model.Product>(viewmodel);
                productRepository.Update(ProductInfo);
                unitOfWork.Commit();
                model.Success = true;
                model.Msg = "成功更新产品信息，页面即将跳转到用产品表页";
                model.RedirectUrl = CurrentUrl;
            }
            catch (Exception ex)
            {
                model.Success = false;
                model.Msg = "更新产品信息失败，请重试" + ex.Message;
            }
            return Json(model);
        }

        public ActionResult Delete(int id)
        {
            Admin.ResponseModel model = new Admin.ResponseModel();
            try
            {
                productRepository.Delete(productRepository.GetById(id));
                unitOfWork.Commit();
                model.Success = true;
                model.Msg = "删除产品成功！";
                model.RedirectUrl = CurrentUrl;
            }
            catch (Exception ex)
            {
                model.Success = false;
                model.Msg = "删除产品失败，请重试" + ex.Message;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
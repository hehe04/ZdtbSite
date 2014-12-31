using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ZdtbSite.Core.Infrastructure;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Controllers
{
    public class BaseController : Controller
    {
        private int loginUserId;
        public int LoginUserId { get { return loginUserId; } }
        public string LoginUserName { get; private set; }

        public string LoginUserEmail { get; private set; }

        public string LoginUserAuthorityUrl { get; private set; }

        protected override void OnException(ExceptionContext filterContext)
        {
            //Response.Redirect(Url.Action("Index", "Error"));
            base.OnException(filterContext);
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            string action = filterContext.RouteData.Values["Action"].ToString();
            string controller = filterContext.RouteData.Values["Controller"].ToString();
            if (controller.ToLower().Equals("error"))
            {
                return;
            }
            if (string.Equals(action, "SingIn", StringComparison.OrdinalIgnoreCase)) { return; }
            if (string.Equals(action, "SingOut", StringComparison.OrdinalIgnoreCase)) { return; }
            if (HttpContext.Request.IsAuthenticated)
            {
                HttpCookie authCookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];//获取cookie 
                FormsAuthenticationTicket Ticket = FormsAuthentication.Decrypt(authCookie.Value);//解密 
                string[] userData = Ticket.UserData.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                if (userData.Length < 4)
                {
                    Response.Redirect(Url.Action("SingIn", "User"));
                }
                if (!int.TryParse(userData[0], out loginUserId))
                {
                    Response.Redirect(Url.Action("SingIn", "User"));
                }
                LoginUserName = userData[1];
                LoginUserEmail = userData[2];
                LoginUserAuthorityUrl = userData[3];
                HttpContext.Items.Add("LoginUserName", LoginUserName);
                HttpContext.Items.Add("LoginUserId", LoginUserId);
                HttpContext.Items.Add("AuthorityUrl", LoginUserAuthorityUrl);
                //TODO 加载留言板的数据

                ZdtbSite.Core.Repository.FeedbackRepository repository = new Core.Repository.FeedbackRepository(new DbContextFactory());
                var list = repository.GetAll().OrderByDescending(e => e.CreateTime).Take(3).ToList();

                HttpContext.Items.Add("FeedBackList", list);
            }
            else
            {
                // TODO 请登录
                Response.Redirect(Url.Action("SingIn", "User"));
            }
            base.OnAuthorization(filterContext);
        }


        public void GetImageUrl(HttpPostedFileBase hpFill, ref string MaxImgURL, ref string MiniImgURL)
        {
            if (hpFill.ContentType.IndexOf("image") > -1)
            {
                //得到上传的图片名 hpFill.FileName得到客户端上传文件的路劲
                string fillName = System.IO.Path.GetFileName(hpFill.FileName);
                string path = "/Images/uploadImages/";
                //获取保存路径
                string filePath = HttpContext.Server.MapPath(path);
                //判断路径是否存 创建路径
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string guid = Guid.NewGuid().ToString();
                //保存大图
                MaxImgURL = path + guid + "_Max_" + fillName;
                string savePath = filePath + guid + "_Max_" + fillName;
                hpFill.SaveAs(savePath);

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
                            MiniImgURL = path + guid + "_Mini_" + fillName;
                            savePath = filePath + guid + "_Mini_" + fillName;
                            bit.Save(savePath);
                        }
                    }
                }
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Core.Helper
{
    public static class EmailHelper
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="emailList">接收邮件地址集合</param>
        /// <param name="sendName">发件人名称</param>
        /// <param name="id">发送邮件账号</param>
        /// <param name="pwd">发送邮件密码</param>
        /// <param name="Server">发送邮件服务</param>
        /// <param name="Port">端口</param>
        /// <param name="subject">邮件主题</param>
        /// <param name="content">邮件内容</param>
        public static void SendEmail(List<string> emailList, string sendName, string subject, string content)
        {
            ZdtbSite.Core.Repository.BasicInfoRepository repository = new Core.Repository.BasicInfoRepository(new DbContextFactory());
            Dictionary<string, string> dic = new Dictionary<string, string>();
            var list = repository.GetAll().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                dic.Add(list[i].Key, list[i].Value);
            }
            string id, pwd, Server;
            int Port = 25;
            try
            {
                id = dic["mailUser"]; pwd = dic["mailPwd"]; Server = dic["mailServer"];
                if (dic.ContainsKey("mailPort")) Port = Convert.ToInt32(dic["mailPort"]);
            }
            catch (Exception ex)
            {
                throw new Exception("邮件配置有误！" + ex.Message);
            }
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(id, sendName);//发送人地址、发送人名称
            for (int i = 0; i < emailList.Count; i++)
            {
                mail.To.Add(emailList[i]);
            }
            mail.Subject = subject;
            mail.Body = content;
            mail.BodyEncoding = Encoding.Default;
            mail.Priority = MailPriority.Normal;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient(Server, Port);
            smtp.UseDefaultCredentials = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential(id, pwd);
            smtp.Send(mail);
        }

    }
}

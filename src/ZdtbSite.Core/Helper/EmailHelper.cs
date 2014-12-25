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
        /// 发送邮件  需在BasicInfo中配置 
        /// 发送账户id：mailUser
        /// 发送账户密码：mailPwd
        /// 服务：mailServer
        /// 端口：mailPort
        /// </summary>
        /// <param name="emailList">接收邮件地址集合</param>
        /// <param name="sendName">发件人名称</param>
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
            mail.BodyEncoding = UTF8Encoding.UTF8;
            mail.Subject = subject;
            mail.Body = content;
            mail.BodyEncoding = Encoding.Default;
            mail.Priority = MailPriority.Normal;
            mail.IsBodyHtml = true;
            mail.BodyEncoding = UTF8Encoding.UTF8;
            SmtpClient smtp = new SmtpClient(Server, Port);
            smtp.UseDefaultCredentials = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential(id, pwd);
            smtp.Send(mail);
        }

        /// <summary>
        /// 发送邮件  需在BasicInfo中配置 
        /// 接受邮件emial集合：receiveEmailList  用分号分割
        /// 发送账户id：mailUser
        /// 发送账户密码：mailPwd
        /// 服务：mailServer
        /// 端口：mailPort
        /// <param name="sendName">发送人名称</param>
        /// <param name="subject">邮件主题</param>
        /// <param name="content">邮件内容</param>
        public static void SendEmail(string sendName, string subject, string content)
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
            if (!dic.ContainsKey("receiveEmailList")) throw new Exception("接收人地址为空！");
            string[] receiveEmailArr = dic["receiveEmailList"].Split(';');
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(id, sendName);//发送人地址、发送人名称
            for (int i = 0; i < receiveEmailArr.Length; i++)
            {
                mail.To.Add(receiveEmailArr[i]);
            }
            mail.Subject = subject;
            mail.Body = content;
            mail.BodyEncoding = Encoding.Default;
            mail.Priority = MailPriority.Normal;
            mail.IsBodyHtml = true;
            mail.BodyEncoding = UTF8Encoding.UTF8;
            SmtpClient smtp = new SmtpClient(Server, Port);
            smtp.UseDefaultCredentials = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential(id, pwd);
            smtp.Send(mail);
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="emailList">接受者集合</param>
        /// <param name="sendName">发送人</param>
        /// <param name="subject">邮件主题</param>
        /// <param name="content">邮件内容</param>
        /// <param name="id">发送者账户ID</param>
        /// <param name="pwd">发送者账户密码</param>
        /// <param name="Server">邮件服务</param>
        /// <param name="Port">端口</param>
        public static void SendEmail(List<string> emailList, string sendName, string subject, string content, string id, string pwd, string Server, int Port)
        {

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
            mail.BodyEncoding = UTF8Encoding.UTF8;
            smtp.Send(mail);
        }

    }
}

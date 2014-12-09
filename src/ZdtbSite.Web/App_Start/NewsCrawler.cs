using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.IO;
using ZdtbSite.Model;
using ZdtbSite.Core.Infrastructure;
using System.Web.Mvc;
namespace ZdtbSite.Web
{
    public class NewsCrawler
    {
        static ZdtbSite.Core.Repository.ArticleRepository repository = null;
        static IUnitOfWork unitOfWork = null;
        static NewsCrawler()
        {
            var factory = new DbContextFactory();
            repository = new Core.Repository.ArticleRepository(factory);
            unitOfWork = new UnitOfWork(factory);
        }
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
        public static void StartNewTask()
        {
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                WebClient client = new WebClient();
                Regex regexurl = new Regex("<a href=\"(http://ayerstransformers\\.com/\\?p=\\d+)\">(.+)</a>");
                Regex regexcontent = new Regex("<article class=\"entry post clearfix\">[\\w\\s.\\W]+</article>");

                if (!Directory.Exists(CurrentPath))
                {
                    Directory.CreateDirectory(CurrentPath);
                }
                if (!File.Exists(CurrentFile))
                {
                    File.Create(CurrentFile).Close();
                }
                while (true)
                {
                    try
                    {
                        string content = client.DownloadString("http://ayerstransformers.com/?cat=1");
                        MatchCollection collection = regexurl.Matches(content);
                        List<string> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(CurrentFile));
                        if (list == null)
                        {
                            list = new List<string>();
                        }
                        foreach (Match item in collection)
                        {
                            if (!list.Contains(item.Groups[1].Value))
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
                                repository.Add(model);
                                unitOfWork.Commit();
                                list.Add(item.Groups[1].Value);
                            }
                        }
                        File.WriteAllText(CurrentFile, Newtonsoft.Json.JsonConvert.SerializeObject(list));
                        Thread.Sleep(3600000 * 24);
                    }
                    catch (Exception)
                    {

                    }
                }
            });
        }
    }
}
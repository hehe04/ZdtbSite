using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Models
{

    public class ArticleDataViewModel
    {
        public ArticleViewModel Article { get; set; }
        public List<ContentTypeViewModel> ContentTypes { get; set; }
    }

    public class ArticleViewModel
    {
        public int Id { get; set; }

        [Display(Name="标题")]
        [Required(ErrorMessage="文章标题必须输入.")]
        public string Title { get; set; }

        public string Publisher { get; set; }

        public DateTime PublisherDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }
        [Display(Name="发布")]
        public bool IsPublish { get; set; }

        /// <summary>
        /// 文章来源类型
        /// </summary>
        public OriginArticlesType OriginArticlesType { get; set; }

        [Display(Name = "内容")]
        [Required(ErrorMessage = "文章内容必须输入.")]
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        [Display(Name="文章类型")]
        public ContentTypeViewModel ContentType { get; set; }

        public int ContentTyepId { get; set; }

        [Display(Name = "标签，以,或者|分割")]
        [Required(ErrorMessage = "文章内容必须输入.")]
        public string Tag { get; set; }

        public string ImgUrl { get; set; }

        public string ThumbnailUrl { get; set; }

        public ArticleViewModel()
        {
            PublisherDateTime = DateTime.Now;
        }

    }

    public enum OriginArticlesType
    {
        Web = 0,//互联网采集
        User = 1//用户自定义
    }

    public class ContentTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int PrentId { get; set; }

        public virtual ICollection<ArticleViewModel> Articles { get; set; }
    }
}
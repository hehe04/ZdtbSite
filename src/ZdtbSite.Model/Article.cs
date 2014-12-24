using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZdtbSite.Model
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [StringLength(512)]
        public string Title { get; set; }

        [StringLength(128)]
        public string Publisher { get; set; }

        public DateTime PublisherDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }

        public bool IsPublish { get; set; }

        /// <summary>
        /// 文章来源类型
        /// </summary>  
        public OriginArticlesType OriginArticlesType { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Column(TypeName = "nText")]
        [MaxLength]
        public string Content { get; set; }

        [ForeignKey("ContentTyepId")]
        public virtual ContentType ContentType { get; set; }

        public int ContentTyepId { get; set; }

        [StringLength(256)]
        public string Tag { get; set; }

        [StringLength(1024)]
        public string ImgUrl { get; set; }

        [StringLength(1024)]
        public string ThumbnailUrl { get; set; }

        public Article()
        {
            PublisherDateTime = DateTime.Now;
        }

    }

    public enum OriginArticlesType
    {
        Web = 0,//互联网采集
        User = 1//用户自定义
    }
}

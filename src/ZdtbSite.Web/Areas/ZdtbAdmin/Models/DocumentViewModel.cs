using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZdtbSite.Web.Areas.ZdtbAdmin.Models
{
    public class DocumentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "请输入文档标题")]
        [Display(Name = "文档标题")]
        public string Title { get; set; }
        [Display(Name = "文档路劲")]
        public string Path { get; set; }
        [Display(Name = "文档描述")]
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DocumentViewModel()
        {
            CreateDate = DateTime.Now;
        }

    }
}
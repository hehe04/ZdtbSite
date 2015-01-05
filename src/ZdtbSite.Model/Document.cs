using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdtbSite.Model
{
    public class Document
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Path { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateBy { get; set; }

        public Document()
        {
            CreateDate = DateTime.Now;
        }
    }
}

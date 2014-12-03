using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZdtbSite.Model
{
    public class ContentType
    {
        [Key]
        public int Id { get; set; }

        [StringLength(64)]
        public string Name { get; set; }

        [StringLength(128)]
        public string Description { get; set; }

        public int PrentId { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}

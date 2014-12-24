using System.ComponentModel.DataAnnotations;


namespace ZdtbSite.Model
{
    public class BasicInfo
    {
        [Key]
        public int Id { get; set; }

        public string Value { get; set; }

        public string Key { get; set; }

        public string Description { get; set; }
    }
}

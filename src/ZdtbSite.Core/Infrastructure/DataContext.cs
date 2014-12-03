using System.Data.Entity;
using ZdtbSite.Model;


namespace ZdtbSite.Core.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DataContext")
        {
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<ProductType> ProductTypes { get; set; }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<BasicInfo> BasicInfos { get; set; }

        public IDbSet<ContentType> ContentTypes { get; set; }

        public IDbSet<UserInfo> UserInfos { get; set; }

        public IDbSet<VisitLog> VisitLogs { get; set; }

        public IDbSet<AdminMenu> AdminMenus { get; set; }

        public IDbSet<Recruitment> Recruitments { get; set; }

        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<Feedback> Feedbacks { get; set; }

        public IDbSet<Contract> Contracts { get; set; }
    }
}

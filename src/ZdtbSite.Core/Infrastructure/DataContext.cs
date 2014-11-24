using System.Data.Entity;
using ZdtbSite.Model;


namespace ZdtbSite.Core.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DataContext")
        {
            //base.Configuration.ProxyCreationEnabled = false;
            //base.Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<ProductType> ProductTypes { get; set; }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<BasicInfo> BasicInfos { get; set; }

        public IDbSet<ContentType> ContentTypes { get; set; }

        public IDbSet<UserInfo> UserInfos { get; set; }

        public IDbSet<VisitLog> VisitLogs { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdtbSite.Model;


namespace ZdtbSite.Core.Infrastructure
{
    public class DataContext : DbContext, IRepository
    {
        public DataContext()
            : base("DataContext")
        {
<<<<<<< HEAD
            base.Configuration.ProxyCreationEnabled = false;
            base.Configuration.LazyLoadingEnabled = false;
=======
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
>>>>>>> 5a14c33c19ee9fa44d5b20f7ee579198af28e6be
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<ProductType> ProductTypes { get; set; }

<<<<<<< HEAD
=======
        public IDbSet<Article> Articles { get; set; }

        public IDbSet<BasicInfo> BasicInfos { get; set; }

        public IDbSet<ContentType> ContentTypes { get; set; }

        public IDbSet<UserInfo> UserInfos { get; set; }

        public IDbSet<VisitLog> VisitLogs { get; set; }
>>>>>>> 5a14c33c19ee9fa44d5b20f7ee579198af28e6be
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ZdtbSite.Model;

namespace ZdtbSite.Core.Infrastructure
{
    public interface IRepository
    {
        IDbSet<Product> Products { get; set; }

        IDbSet<ProductType> ProductTypes { get; set; }

<<<<<<< HEAD
=======
        IDbSet<Article> Articles { get; set; }

        IDbSet<BasicInfo> BasicInfos { get; set; }

        IDbSet<ContentType> ContentTypes { get; set; }

        IDbSet<UserInfo> UserInfos { get; set; }

        IDbSet<VisitLog> VisitLogs { get; set; }

        int SaveChanges();
>>>>>>> 5a14c33c19ee9fa44d5b20f7ee579198af28e6be
    }
}

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
            : base("DataContext") { }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<ProductType> ProductTypes { get; set; }
    }
}

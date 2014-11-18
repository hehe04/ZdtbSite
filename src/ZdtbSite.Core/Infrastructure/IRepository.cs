using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdtbSite.Model;

namespace ZdtbSite.Core.Infrastructure
{
    public interface IRepository
    {
        IDbSet<Product> Products { get; set; }

        IDbSet<ProductType> ProductTypes { get; set; }

    }
}

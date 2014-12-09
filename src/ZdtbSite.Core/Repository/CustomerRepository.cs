using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Core.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, IRepository<Customer>
    {
        public CustomerRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory)
        {
        }
    }
}

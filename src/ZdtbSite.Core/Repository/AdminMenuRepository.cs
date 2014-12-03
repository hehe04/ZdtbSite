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
    public class AdminMenuRepository : RepositoryBase<AdminMenu>, IRepository<AdminMenu>
    {
        public AdminMenuRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory)
        {
        }

        public IDbSet<AdminMenu> DbSet { get; set; }
    }
}

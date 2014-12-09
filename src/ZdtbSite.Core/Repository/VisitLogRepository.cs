using System.Data.Entity;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Core.Repository
{
    public class VisitLogRepository : RepositoryBase<VisitLog>, IRepository<VisitLog>

    {
        public VisitLogRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory)
        {
        }
    }
}

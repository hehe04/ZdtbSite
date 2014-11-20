using System.Data.Entity;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Core.Repository
{
    public class BasicInfoRepository : RepositoryBase<BasicInfo>, IRepository<BasicInfo>
    {
        public BasicInfoRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory)
        {
        }

        public IDbSet<BasicInfo> DbSet { get; set; }
    }
}

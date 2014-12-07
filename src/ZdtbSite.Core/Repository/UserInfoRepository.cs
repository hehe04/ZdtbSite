using System.Data.Entity;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Core.Repository
{
    public class UserInfoRepository : RepositoryBase<UserInfo>, IRepository<UserInfo>
    {
        public UserInfoRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory)
        {
        }
    }
}

using System.Data.Entity;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Core.Repository
{
    public class ArticleRepository : RepositoryBase<Article>, IRepository<Article>
    {
        public ArticleRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory)
        {
        }

        public IDbSet<Article> DbSet { get; set; }
    }
}

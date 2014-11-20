using System.Data.Entity;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Core.Repository
{
    public class ContentTypeRepository : RepositoryBase<ContentType>, IRepository<ContentType>
    {
        public ContentTypeRepository(DataContext context)
            : base(context)
        {
        }

        public IDbSet<ContentType> DbSet { get; set; }
    }
}

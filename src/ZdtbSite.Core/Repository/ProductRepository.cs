using System.Data.Entity;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Core.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IRepository<Product>
    {
        public ProductRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory)
        {
        }

        public IDbSet<Product> DbSet { get; set; }
    }
}

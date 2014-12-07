using System.Data.Entity;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Core.Repository
{
    public class ProductTypeRepository : RepositoryBase<ProductType>, IRepository<ProductType>
    {
        public ProductTypeRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory)
        {
        }
    }
}

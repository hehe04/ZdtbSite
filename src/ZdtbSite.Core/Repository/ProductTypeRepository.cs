using System.Data.Entity;
using ZdtbSite.Core.Infrastructure;
using ZdtbSite.Model;

namespace ZdtbSite.Core.Repository
{
    public class ProductTypeRepository : RepositoryBase<ProductType>, IRepository<ProductType>
    {
        public ProductTypeRepository(DataContext context) : base(context)
        {
        }

        public IDbSet<ProductType> DbSet { get; set; }
    }
}

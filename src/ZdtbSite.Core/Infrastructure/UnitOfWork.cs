using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdtbSite.Core.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext dataContext;
        private IDbContextFactory dbContextFactory;

        public UnitOfWork(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public DataContext DataContext
        {
            get { return dataContext ?? (dataContext = dbContextFactory.DataContext); }
        }

        public void Commit()
        {
            dataContext.SaveChanges();
        }
    }
}

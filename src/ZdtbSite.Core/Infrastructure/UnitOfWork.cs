using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdtbSite.Core.Infrastructure
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private DataContext dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public DataContext DataContext
        {
            get { return dataContext ?? (dataContext = new DataContext()); }
        }

        public void Commit()
        {
            dataContext.SaveChanges();
        }

        public override void DisposeCore()
        {
            if (dataContext != null)
            {
                dataContext.Dispose();
            }
        }
    }
}

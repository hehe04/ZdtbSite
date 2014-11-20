namespace ZdtbSite.Core.Infrastructure
{
    public interface IDbContextFactory
    {
        DataContext DataContext { get; }
    }

    public class DbContextFactory : Disposable
    {
        private DataContext dataContext;

        public DataContext DataContext
        {
            get { return dataContext ?? (dataContext = new DataContext()); }
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

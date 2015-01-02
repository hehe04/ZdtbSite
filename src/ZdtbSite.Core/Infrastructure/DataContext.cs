using System.Data.Entity;
using ZdtbSite.Model;


namespace ZdtbSite.Core.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DataContext")
        {
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<ProductType> ProductTypes { get; set; }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<BasicInfo> BasicInfos { get; set; }

        public IDbSet<ContentType> ContentTypes { get; set; }

        public IDbSet<UserInfo> UserInfos { get; set; }

        public IDbSet<VisitLog> VisitLogs { get; set; }

        public IDbSet<AdminMenu> AdminMenus { get; set; }

        public IDbSet<Recruitment> Recruitments { get; set; }

        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<Feedback> Feedbacks { get; set; }

        public IDbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //映射Feedback Customer 主外键关系
            modelBuilder.Entity<Feedback>()
                .HasRequired(t => t.Customer)
                .WithMany(c => c.Feedbacks)
                .HasForeignKey(f => f.CustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .HasRequired(a => a.ContentType)
                .WithMany(c => c.Articles)
                .HasForeignKey(a => a.ContentTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contract>()
                .HasRequired(c => c.Customer)
                .WithMany(c => c.Contracts)
                .HasForeignKey(c => c.CustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VisitLog>()
                .HasRequired(v => v.ExploreProducts)
                .WithMany(p => p.VisitLogs)
                .HasForeignKey(v => v.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasRequired(p => p.ProductType)
                .WithMany(t => t.Products)
                .HasForeignKey(p => p.ProductTypeId)
                .WillCascadeOnDelete(false);


        }
    }
}

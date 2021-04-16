using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.Framework
{
    public partial class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext()
            : base("name=OnlineShopDbContext")
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<New> News { get; set; }
        public virtual DbSet<NewCategory> NewCategories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.FooterID)
                .IsUnicode(false);

            modelBuilder.Entity<New>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<New>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<New>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<New>()
                .Property(e => e.TagID)
                .IsUnicode(false);

            modelBuilder.Entity<New>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.News)
                .Map(m => m.ToTable("NewTag").MapLeftKey("NewID").MapRightKey("TagID"));

            modelBuilder.Entity<NewCategory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<NewCategory>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<NewCategory>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.Data)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductCode)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.ConfigID)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.TagID)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Username)
                .IsFixedLength();

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Payment)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.PaymentInfo)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Security)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);
        }
    }
}

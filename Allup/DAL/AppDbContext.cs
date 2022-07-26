using Allup.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Allup.DAL
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderContent> SliderContents { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagProducts> TagProducts { get; set; }
        public DbSet<Testonominal> Testonominals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Testonominal>().HasData
                (
            new Testonominal {Id=1, AuthorName = "John Doe", Content = "An has feugiat vivendum, ad vix tacimates accusamus, cum commune lucilius no. Sit at alia civibus indoctum, ea mel regione percipit adipisci. Per modus nostrum vituperata no, eam ne magna solum constituam.", ImgUrl = "author-1.png", Site = "email@yourwebsitename.com" },
            new Testonominal {Id=2, AuthorName = "John Doe", Content = "An has feugiat vivendum, ad vix tacimates accusamus, cum commune lucilius no. Sit at alia civibus indoctum, ea mel regione percipit adipisci. Per modus nostrum vituperata no, eam ne magna solum constituam.", ImgUrl = "author-1.png", Site = "email@yourwebsitename.com" },
            new Testonominal {Id=3, AuthorName = "John Doe", Content = "An has feugiat vivendum, ad vix tacimates accusamus, cum commune lucilius no. Sit at alia civibus indoctum, ea mel regione percipit adipisci. Per modus nostrum vituperata no, eam ne magna solum constituam.", ImgUrl = "author-1.png", Site = "email@yourwebsitename.com" }

            );
        }
    }
}

using Allup.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

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
        public DbSet<SubscripeSection> SubscripeSections { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Testonominal>().HasData
                (
            new Testonominal { Id = 1, AuthorName = "John Doe", Content = "An has feugiat vivendum, ad vix tacimates accusamus, cum commune lucilius no. Sit at alia civibus indoctum, ea mel regione percipit adipisci. Per modus nostrum vituperata no, eam ne magna solum constituam.", ImgUrl = "author-1.png", Site = "email@yourwebsitename.com" },
            new Testonominal { Id = 2, AuthorName = "John Doe", Content = "An has feugiat vivendum, ad vix tacimates accusamus, cum commune lucilius no. Sit at alia civibus indoctum, ea mel regione percipit adipisci. Per modus nostrum vituperata no, eam ne magna solum constituam.", ImgUrl = "author-1.png", Site = "email@yourwebsitename.com" },
            new Testonominal { Id = 3, AuthorName = "John Doe", Content = "An has feugiat vivendum, ad vix tacimates accusamus, cum commune lucilius no. Sit at alia civibus indoctum, ea mel regione percipit adipisci. Per modus nostrum vituperata no, eam ne magna solum constituam.", ImgUrl = "author-1.png", Site = "email@yourwebsitename.com" }
                );
            builder.Entity<SubscripeSection>().HasData
                (
                new SubscripeSection { Id=1,Title= "Subscribe our newsletter",Desc= "allup is a powerful eCommerce HTML Template",ImgUrl= "bg-newletter.jpg" }
                );
            builder.Entity<Banner>().HasData
                (
               new Banner { Id = 1, ImgUrl = "banner-1.png" },
               new Banner { Id = 2, ImgUrl = "banner-2.png" }
                );
            builder.Entity<Bio>().HasData
                (
                new Bio { Id = 1, ShippinValue = 35, Logo = "logo.png", PhoneNotified = "24/7 Support", MobilePhone = "+48 500 500 500", AuthorName = "Tural", Adress = "45 Grand Central Terminal New York,NY 1017 United State USA", PhoneNumber = "+123 456 789", WebSite = "email@yourwebsitename.com", Scheduler = "Mon-Sat 9:00pm - 5:00pm Sun:Closed" }
                );
            builder.Entity<User>().HasData
                (
                new User { Id = "admin", FullName = "Tural Cavadov" }
                );
            builder.Entity<Blog>().HasData
                (
                new Blog { Id = 1, ImgUrl = "blog-1.jpg", CreatedAt = DateTime.Now, Title = "This is Third Post For XipBlog", Desc = "simply dummy text of the printing and typesetting industry. Lorem Ipsum ...", UserId = "admin", CategoryId = 1 },
                new Blog { Id = 2, ImgUrl = "blog-2.jpg", CreatedAt = DateTime.Now, Title = "This is Third Post For XipBlog", Desc = "simply dummy text of the printing and typesetting industry. Lorem Ipsum ...", UserId = "admin", CategoryId = 1 },
                new Blog { Id = 3, ImgUrl = "blog-3.jpg", CreatedAt = DateTime.Now, Title = "This is Third Post For XipBlog", Desc = "simply dummy text of the printing and typesetting industry. Lorem Ipsum ...", UserId = "admin", CategoryId = 1 },
                new Blog { Id = 4, ImgUrl = "blog-4.jpg", CreatedAt = DateTime.Now, Title = "This is Third Post For XipBlog", Desc = "simply dummy text of the printing and typesetting industry. Lorem Ipsum ...", UserId = "admin", CategoryId = 1 }
                );
            builder.Entity<Slider>().HasData
                (
                new Slider { Id = 1, ImgUrl = "slider-1.jpg" },
                new Slider { Id = 2, ImgUrl = "slider-2.jpg" }
                );
            builder.Entity<SliderContent>().HasData
                (
                new SliderContent { Id = 1, SubTitle = "Save $120 when you buy", MainTitle = "<span>4K HDR Smart TV 43 </span> Sony Bravia.", Description = "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform" },
                new SliderContent { Id = 2, SubTitle = "Save $120 when you buy", MainTitle = "<span>4K HDR Smart TV 43 </span> Sony Bravia.", Description = "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform" }
                );
            builder.Entity<Category>().HasData
                (
                new Category { Id = 1, Name = "Laptop", IsDeleted = false, ImgUrl = "category-1.jpg", CreatedAt = DateTime.Now },
                new Category { Id = 2, Name = "Computer", IsDeleted = false, ImgUrl = "category-2.jpg", CreatedAt = DateTime.Now },
                new Category { Id = 3, Name = "Smartphone", IsDeleted = false, ImgUrl = "category-3.jpg", CreatedAt = DateTime.Now },
                new Category { Id = 4, Name = "Game Consoles", IsDeleted = false, ImgUrl = "category-4.jpg", CreatedAt = DateTime.Now },
                new Category { Id = 7, Name = "Bottoms", ParentId = 1, IsDeleted = false,  CreatedAt = DateTime.Now },
                new Category { Id = 8, Name = "Tops & Sets", ParentId = 2, IsDeleted = false,  CreatedAt = DateTime.Now },
                new Category { Id = 9, Name = "Audio & Video", ParentId = 3, IsDeleted = false,  CreatedAt = DateTime.Now },
                new Category { Id = 10, Name = "Accessories", ParentId = 2, IsDeleted = false, CreatedAt = DateTime.Now },
                new Category { Id = 11, Name = "Camera", ParentId = 3, IsDeleted = false, CreatedAt = DateTime.Now },
                new Category { Id = 12, Name = "Accessories2", ParentId = 4, IsDeleted = false, CreatedAt = DateTime.Now },
                new Category { Id = 13, Name = "Games & Consoles", ParentId = 4, IsDeleted = false, CreatedAt = DateTime.Now },
                new Category { Id = 14, Name = "Video Games", ParentId = 4, IsDeleted = false, CreatedAt = DateTime.Now }
                );
            builder.Entity<ProductImage>().HasData
                (
                new ProductImage { Id = 1, ImgUrl = "product-1.jpg", IsMain = true, ProductId = 1 },
                new ProductImage { Id = 2, ImgUrl = "product-2.jpg", IsMain = false, ProductId = 1 },
                new ProductImage { Id = 3, ImgUrl = "product-3.jpg", IsMain = true, ProductId = 2 },
                new ProductImage { Id = 4, ImgUrl = "product-4.jpg", IsMain = false, ProductId = 2 },
                new ProductImage { Id = 5, ImgUrl = "product-5.jpg", IsMain = false, ProductId = 2 },
                new ProductImage { Id = 6, ImgUrl = "product-6.jpg", IsMain = true, ProductId = 3 },
                new ProductImage { Id = 7, ImgUrl = "product-7.jpg", IsMain = false, ProductId = 3 },
                new ProductImage { Id = 8, ImgUrl = "product-8.jpg", IsMain = true, ProductId = 4 },
                new ProductImage { Id = 9, ImgUrl = "product-9.jpg", IsMain = false, ProductId = 4 },
                new ProductImage { Id = 10, ImgUrl = "product-10.jpg", IsMain = false, ProductId = 1 },
                new ProductImage { Id = 11, ImgUrl = "product-11.jpg", IsMain = false, ProductId = 2 },
                new ProductImage { Id = 12, ImgUrl = "product-12.jpg", IsMain = false, ProductId = 3 },
                new ProductImage { Id = 13, ImgUrl = "product-13.jpg", IsMain = false, ProductId = 4 },
                new ProductImage { Id = 14, ImgUrl = "product-14.jpg", IsMain = false, ProductId = 1 },
                new ProductImage { Id = 15, ImgUrl = "product-15.jpg", IsMain = false, ProductId = 2 },
                new ProductImage { Id = 16, ImgUrl = "product-16.jpg", IsMain = false, ProductId = 3 },
                new ProductImage { Id = 17, ImgUrl = "product-17.jpg", IsMain = false, ProductId = 4 }
                );
            builder.Entity<Brand>().HasData
                (
                new Brand { Id = 1, Name = "brand1", IsDeleted = false, CreatedAt = DateTime.Now },
                new Brand { Id = 2, Name = "brand2", IsDeleted = false, CreatedAt = DateTime.Now },
                new Brand { Id = 3, Name = "brand3", IsDeleted = false, CreatedAt = DateTime.Now },
                new Brand { Id = 4, Name = "brand4", IsDeleted = false, CreatedAt = DateTime.Now }
                );
            builder.Entity<Language>().HasData
                (
                new Language { Id = 1, Name = "English", FlagUrl = "1.jpg" },
                new Language { Id = 2, Name = "Français", FlagUrl = "2.jpg" }

                );
            builder.Entity<Tag>().HasData
                (
                new Tag { Id = 1, Name = "New" },
                new Tag { Id = 2, Name = "Bags" },
                new Tag { Id = 3, Name = "Kids" },
                new Tag { Id = 4, Name = "Electronic" },
                new Tag { Id = 5, Name = "Shirts" },
                new Tag { Id = 6, Name = "Game" },
                new Tag { Id = 7, Name = "Camera" }
                );
            builder.Entity<Product>().HasData
                (
                new Product { Id = 1, Name = "Product1", IsBestSeller = true, IsNewArrivel = true, IsFeatured = false, Price = 50, Count = 5, CreatedAt = DateTime.Now, CategoryId = 7, BrandId = 1 },
                new Product { Id = 2, Name = "Product2", IsBestSeller = true, IsNewArrivel = true, IsFeatured = false, Price = 55, Count = 3, CreatedAt = DateTime.Now, CategoryId = 8, BrandId = 2 },
                new Product { Id = 3, Name = "Product3", IsBestSeller = false, IsNewArrivel = false, IsFeatured = true, Price = 65, Count = 5, CreatedAt = DateTime.Now, CategoryId = 9, BrandId = 3 },
                new Product { Id = 4, Name = "Product4", IsBestSeller = false, IsNewArrivel = false, IsFeatured = true, Price = 75, Count = 6, CreatedAt = DateTime.Now, CategoryId = 10, BrandId = 4 }
                );
            builder.Entity<TagProducts>().HasData
                (
                new TagProducts { Id = 1, ProductId = 1, TagId = 1 },
                new TagProducts { Id = 2, ProductId = 2, TagId = 2 },
                new TagProducts { Id = 3, ProductId = 3, TagId = 1 },
                new TagProducts { Id = 4, ProductId = 2, TagId = 3 },
                new TagProducts { Id = 5, ProductId = 2, TagId = 4 }

                );

        }
    }
}

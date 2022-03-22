public static class ProductDatabaseBuilder
{
    static void SetDataToDB(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Cat Food"
            },
            new Category
            {
                Id = 2,
                Name = "Dog Food"
            }
        );
        modelBuilder.Entity<Company>().HasData(
            new Company
            {
                Id = 1,
                Name = "BlaBla Sirketi"
            },
            new Company
            {
                Id = 2,
                Name = "BlaBlaBla Sirketi"
            }
        );
        modelBuilder.Entity<Brand>().HasData(
        new Brand
        {
            Id = 1,
            Name = "Pro Plan"
        },
        new Brand
        {
            Id = 2,
            Name = "Pro Line"
        }
    );
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Pro Plan Active",
                UnitPrice = 15,
                UnitsInStock = 10,
                BrandId = 1,
                CategoryId = 1,
                CompanyId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Pro Line Active",
                UnitPrice = 10,
                UnitsInStock = 15,
                BrandId = 2,
                CategoryId = 2,
                CompanyId = 2
            }
        );

    }
    public static void TableBuilder(ModelBuilder modelBuilder)
    {
                modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.HasOne(p => p.Category).WithMany(c => c!.Products).HasForeignKey(p => p.CategoryId);
            entity.HasOne(b => b.Brand).WithMany(c => c!.Products).HasForeignKey(b => b.BrandId);
            entity.HasOne(c => c.Company).WithMany(c => c!.Products).HasForeignKey(c => c.CompanyId);
        });

    SetDataToDB(modelBuilder);
    }
}
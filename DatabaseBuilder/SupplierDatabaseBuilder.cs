public static class SupplierDatabaseBuilder
{


    static void SetDataToDB(ModelBuilder modelBuilder)
    {
       
    }
    public static void TableBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e=> e.Email).IsRequired();
            entity.Property(e=>e.Rating);
            entity.Property(e=>e.IsVisibility);
            entity.HasOne(e=>e.Address).WithMany(r=>r.Suppliers).HasForeignKey(i=>i.AddressId);
            entity.HasMany(e=>e.Account).WithMany(r=>r.Suppliers)
                .UsingEntity<AccountSupplier>(
                    x => x.HasOne(x => x.Account).WithMany().HasForeignKey(x => x.AccountId),
                    x => x.HasOne(x => x.Supplier).WithMany().HasForeignKey(x => x.SupplierId)
                );
            entity.HasMany(e=>e.Brand).WithMany(r=>r.Suppliers)
                .UsingEntity<BrandSupplier>(
                    x => x.HasOne(x => x.Brand).WithMany().HasForeignKey(x => x.BrandId),
                    x => x.HasOne(x => x.Supplier).WithMany().HasForeignKey(x => x.SupplierId)
                );
            
        });
    }

}
public static class IncidenceDatabaseBuilder
{
    static void SetDataToDB(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Incidence>().HasData(
            new Incidence{
                Id=1,
                Name="Kedi kotu durumda",
                Visibility=true,
                Description = "kedi çok aç ve susuz ayrıca ayagı yaralı olabilir",
                UserId = 1,
                DistrictId = 1,
                OpenAddress = "adres sokak no=4",
                Date = DateTime.Today
            },
            new Incidence{
                Id=2,
                Name="Kopek ac",
                Visibility=true ,
                Description = "köpek çok aç acil yardım",
                UserId = 2,
                DistrictId = 4,
                OpenAddress = "abc sokak no=8",
                Date = DateTime.Today
            }
        );

        //geçici olarak
        modelBuilder.Entity<User>().HasData(
            new User{
                Id=1,
                Name="Melek"
            },
             new User{
                Id=2,
                Name="Furkan"
            }
        );
    }

    public static void TableBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Incidence>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.HasOne(p => p.District).WithMany(c => c!.IncidenceList).HasForeignKey(e=>e.DistrictId);
            entity.HasOne(b => b.User).WithMany(c => c!.IncidenceList).HasForeignKey(e=>e.UserId);
            entity.Property(e=>e.Visibility);
            entity.Property(e=>e.Description);
            entity.Property(e=>e.Image);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });

        SetDataToDB(modelBuilder);
    }

}
public static class PetDatabaseBuilder
{
    static void SetDataToDB(ModelBuilder modelBuilder)
    {

    }

    public static void TableBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

        modelBuilder.Entity<PetSpecies>(entity =>
{
    entity.HasKey(e => e.Id);
    entity.Property(e => e.Name).IsRequired();

});

        modelBuilder.Entity<PetSubSpecies>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<PetGender>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });

        SetDataToDB(modelBuilder);
    }

}
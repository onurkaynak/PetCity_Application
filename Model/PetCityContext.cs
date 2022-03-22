public class PetCityContext : DbContext
{
    public DbSet<Product>? Products { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Company>? Companies { get; set; }
    public DbSet<Brand>? Brands { get; set; }
    public DbSet<Supplier>? Suppliers { get; set; }
    public DbSet<Incidence>? Incidences { get; set; }
    public DbSet<User>? Users { get; set; } 
    public DbSet<Pet>? Pets { get; set; }
    public DbSet<PetSpecies>? PetSpecies { get; set; }
    public DbSet<PetGender>? PetGenders { get; set; }
    public DbSet<PetSubSpecies>? PetSubSpecies { get; set; }
    public DbSet<Account>? Account { get; set; }
    public DbSet<Address>? Address { get; set; }
    public DbSet<Country>? Country { get; set; }
    public DbSet<City>? City { get; set; }
    public DbSet<State>? State { get; set; }
    public DbSet<District>? District { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
        optionsBuilder.UseMySql("server=localhost;database=sahabt;user=root;port=3306;password=toortoor", serverVersion);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        AccountDatabaseBuilder.TableBuilder(modelBuilder);
        AddressDatabaseBuilder.TableBuilder(modelBuilder);
        PetDatabaseBuilder.TableBuilder(modelBuilder);
        ProductDatabaseBuilder.TableBuilder(modelBuilder);
        SupplierDatabaseBuilder.TableBuilder(modelBuilder);
        IncidenceDatabaseBuilder.TableBuilder(modelBuilder);
    }
}
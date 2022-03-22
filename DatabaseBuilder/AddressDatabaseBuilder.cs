public static class AddressDatabaseBuilder
{


    static void SetDataToDB(ModelBuilder modelBuilder)
    {

    }
    public static void TableBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
          {
              entity.HasKey(e => e.Id);
              entity.Property(e => e.Name).IsRequired();
              entity.Property(e => e.OpenAddress1);
              entity.Property(e => e.OpenAddress2);
              entity.HasOne(e => e.City).WithMany(e => e.Addresses).HasForeignKey(e => e.CityId);
              entity.HasOne(e => e.Country).WithMany(e => e.Addresses).HasForeignKey(e => e.CountryId);
              entity.HasOne(e => e.District).WithMany(e => e.Addresses).HasForeignKey(e => e.DistrictId);
              entity.HasOne(e => e.State).WithMany(e => e.Addresses).HasForeignKey(e => e.StateId);


          });
        modelBuilder.Entity<Country>(entity =>
       {
           entity.HasKey(e => e.Id);
           entity.Property(e => e.Name).IsRequired();
           entity.Property(e => e.Code);
           entity.Property(e=> e.HasState);
       });

        modelBuilder.Entity<State>(entity =>
         {
             entity.HasKey(e => e.Id);

             entity.Property(e => e.Name).IsRequired();
             entity.HasOne(e => e.Country).WithMany(c => c.state).HasForeignKey(e => e.CountryId);

         });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name);
            entity.HasOne(c => c!.Country).WithMany(c => c!.city).HasForeignKey(c => c.CountryId);
            entity.HasOne(c => c.State).WithMany(c => c.city).HasForeignKey(c => c.StateId);

        });

        modelBuilder.Entity<District>(entity =>
       {
           entity.HasKey(e => e.Id);

           entity.Property(e => e.Name);
           entity.HasOne(c => c.City).WithMany(c => c.District).HasForeignKey(c => c.CityId);
       });

        modelBuilder.Entity<Address>().HasData(
     new Address
     {
         Id = 1,
         Name = "Adems",
         OpenAddress1 = "bagcilar sok mahalllesi",
         OpenAddress2 = "caminin arkasi",
         CountryId = 1,
         CityId = 2,
         DistrictId = 3

     },
     new Address
     {
         Id = 2,
         Name = "Hayris",
         OpenAddress1 = "Pendik sok mahalllesi",
         OpenAddress2 = "caminin karsisi",
         CountryId = 4,
         CityId = 6,
         DistrictId = 11

     },
     new Address
     {
         Id = 3,
         Name = "Muhammed",
         OpenAddress1 = "Bahçelievler sok mahalllesi",
         OpenAddress2 = "kepacinin karsisi",
         CountryId = 2,
         StateId = 2,
         CityId = 4,
         DistrictId = 8

     },
     new Address
     {
         Id = 4,
         Name = "fatihs",
         OpenAddress1 = "sıcak denizler",
         OpenAddress2 = "bir tatil yeri",
         CountryId = 3,
         StateId = 3,
         CityId = 5,
         DistrictId = 10

     },
      new Address
      {
          Id = 5,
          Name = "Ademiş",
          OpenAddress1 = "bagcilar  iş sok mahalllesi",
          OpenAddress2 = "caminin arkasi",
          CountryId = 1,
          CityId = 1,
          DistrictId = 1

      },
      new Address
      {
          Id = 6,
          Name = "Hayri iş",
          OpenAddress1 = "İş adresi sk mahalllesi",
          OpenAddress2 = " sahabt plaza",
          CountryId = 1,
          CityId = 2,
          DistrictId = 4

      }
     );
        modelBuilder.Entity<Country>().HasData(
    new Country
    {
        Id = 1,
        Name = "Turkey",
        Code = 001,
        HasState=false

    },
    new Country
    {
        Id = 2,
        Name = "Usa",
        Code = 002,
        HasState=true

    },
      new Country
      {
          Id = 3,
          Name = "Germany",
          Code = 003,
          HasState=true

      },
      new Country
      {
          Id = 4,
          Name = "England",
          Code = 004,
          HasState=false

      }
);
        modelBuilder.Entity<City>().HasData(
            new City
            {
                Id = 1,
                Name = "Ankara",
                CountryId = 1,



            },
              new City
              {
                  Id = 2,
                  Name = "Istanbul",
                  CountryId = 1,


              },
            new City
            {
                Id = 3,
                Name = "New York City",
                CountryId = 2,
                StateId = 1

            },
              new City
              {
                  Id = 4,
                  Name = "Los Angeles",
                  CountryId = 2,
                  StateId = 2

              },
              new City
              {
                  Id = 5,
                  Name = "Munich",
                  CountryId = 3,
                  StateId = 3

              },
              new City
              {
                  Id = 6,
                  Name = "Londra",
                  CountryId = 4,


              }


        );

        modelBuilder.Entity<State>().HasData(
           new State
           {
               Id = 1,
               Name = "New York",
               CountryId = 2

           },

           new State
           {
               Id = 2,
               Name = "California",
               CountryId = 2

           },
           new State
           {
               Id = 3,
               Name = "Bavyera",
               CountryId = 3

           }

        );

        modelBuilder.Entity<District>().HasData(
          new District
          {
              Id = 1,
              Name = "Kecioren",
              CityId = 1

          },
          new District
          {
              Id = 2,
              Name = "Mamak",
              CityId = 1

          },
          new District
          {
              Id = 3,
              Name = "Bagcılar",
              CityId = 2

          },
          new District
          {
              Id = 4,
              Name = "Besiktas",
              CityId = 2

          },
          new District
          {
              Id = 5,
              Name = "Manhattan",
              CityId = 3

          },
          new District
          {
              Id = 6,
              Name = "Brooklyn",
              CityId = 3

          },
          new District
          {
              Id = 7,
              Name = "Hollywood",
              CityId = 4

          },
          new District
          {
              Id = 8,
              Name = "Santa Monica",
              CityId = 4

          },
          new District
          {
              Id = 9,
              Name = "Altstadt",
              CityId = 5

          },
          new District
          {
              Id = 10,
              Name = "Neuhausen",
              CityId = 5

          },
          new District
          {
              Id = 11,
              Name = "Greenwich",
              CityId = 6

          },
          new District
          {
              Id = 12,
              Name = "Soho",
              CityId = 6

          }
       );
       SetDataToDB(modelBuilder);
    }
}



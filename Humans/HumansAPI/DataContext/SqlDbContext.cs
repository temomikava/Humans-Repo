using HumansAPI.DTOs;
using HumansAPI.Enums;
using HumansAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HumansAPI.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }

        public DbSet<Human>? Humans { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HumanConnection>()
                .HasOne(x => x.FirstHuman)
                .WithMany(x => x.Connections)
                .HasForeignKey(x => x.FirstHumanId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<HumanConnection>()
                .HasOne(x => x.SecondHuman)
                .WithMany()
                .HasForeignKey(x => x.SecondHumanId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<City>().HasData(
                new City {Id=1, Name = "Tbilisi" },
                new City {Id=2, Name = "Batumi" },
                new City {Id=3, Name = "Rustavi" },
                new City {Id=4, Name = "Zugdidi" },
                new City {Id=5, Name = "Qutaisi" }
                );

            builder.Entity<Human>().HasData(
                new Human {Id=1, CityId = 2, DateOfBirth = new DateTime(1998, 5, 14), FirstName = "Temur", LastName = "Mikava", Gender =GenderType.Male, PersonalNumber = "48001233222" },
                new Human {Id=2, CityId = 1, DateOfBirth = new DateTime(1997, 7, 22), FirstName = "Giorgi", LastName = "Giorgadze", Gender = GenderType.Male, PersonalNumber = "48001231122"},
                new Human {Id=3, CityId = 3, DateOfBirth = new DateTime(2000, 12, 14), FirstName = "Natia", LastName = "Natidze", Gender =GenderType.Female, PersonalNumber = "48341233222"},
                new Human {Id=4, CityId = 5, DateOfBirth = new DateTime(2002, 4, 21), FirstName = "Irakli", LastName = "Ikashvili", Gender = GenderType.Male, PersonalNumber = "48005433222"},
                new Human {Id=5, CityId = 4, DateOfBirth = new DateTime(2004, 5, 11), FirstName = "Nata", LastName = "Natashvili", Gender = GenderType.Female, PersonalNumber = "48001267222"},
                new Human {Id=6, CityId = 1, DateOfBirth = new DateTime(1970, 10, 14), FirstName = "Tika", LastName = "Tikashvili", Gender = GenderType.Female, PersonalNumber = "48871233222"},
                new Human {Id=7, CityId = 2, DateOfBirth = new DateTime(2001, 8, 23), FirstName = "Lasha", LastName = "Lashqarava", Gender = GenderType.Male, PersonalNumber = "48001237622"},
                new Human {Id=8, CityId = 3, DateOfBirth = new DateTime(1990, 5, 12), FirstName = "Tazo", LastName = "Tasidze", Gender = GenderType.Male, PersonalNumber = "48001393222"},
                new Human {Id=9, CityId = 4, DateOfBirth = new DateTime(1995, 11, 7), FirstName = "Sandro", LastName = "Sandroshvili", Gender = GenderType.Male, PersonalNumber = "48001233243"},
                new Human {Id=10, CityId = 4, DateOfBirth = new DateTime(1999, 2, 28), FirstName = "Salome", LastName = "Saloshvili", Gender = GenderType.Female, PersonalNumber = "48763233222" }
                );
            builder.Entity<Phone>().HasData(
                new Phone { Id = 1, HumanId = 2, Type = PhoneType.Office, PhoneNumber = "344433334" },
                new Phone { Id = 2, HumanId = 1, Type = PhoneType.Home, PhoneNumber = "4555555" },
                new Phone { Id = 3, HumanId = 8, Type = PhoneType.Office, PhoneNumber = "6476467" },
                new Phone { Id = 4, HumanId = 7, Type = PhoneType.Mobile, PhoneNumber = "34564356" },
                new Phone { Id = 5, HumanId = 2, Type = PhoneType.Mobile, PhoneNumber = "345746756" },
                new Phone { Id = 6, HumanId = 6, Type = PhoneType.Home, PhoneNumber = "34574656" },
                new Phone { Id = 7, HumanId = 10, Type = PhoneType.Office, PhoneNumber = "23455" },
                new Phone { Id = 8, HumanId = 3, Type = PhoneType.Mobile, PhoneNumber = "34565" },
                new Phone { Id = 9, HumanId = 4, Type = PhoneType.Home, PhoneNumber = "34565" },
                new Phone { Id = 10, HumanId = 5, Type = PhoneType.Mobile, PhoneNumber = "345432" }
                );
            builder.Entity<HumanConnection>().HasData(
                new HumanConnection { Id = 1, FirstHumanId = 2, SecondHumanId = 4, Type = ConnectionType.Acquintance },
                new HumanConnection { Id = 2, FirstHumanId = 1, SecondHumanId = 3, Type = ConnectionType.Relative },
                new HumanConnection { Id = 3, FirstHumanId = 3, SecondHumanId = 5, Type = ConnectionType.Acquintance },
                new HumanConnection { Id = 4, FirstHumanId = 8, SecondHumanId = 9, Type = ConnectionType.Other },
                new HumanConnection { Id = 5, FirstHumanId = 7, SecondHumanId = 1, Type = ConnectionType.Colleague },
                new HumanConnection { Id = 6, FirstHumanId = 4, SecondHumanId = 3, Type = ConnectionType.Relative },
                new HumanConnection { Id = 7, FirstHumanId = 9, SecondHumanId = 4, Type = ConnectionType.Other },
                new HumanConnection { Id = 8, FirstHumanId = 2, SecondHumanId = 1, Type = ConnectionType.Relative },
                new HumanConnection { Id = 9, FirstHumanId = 7, SecondHumanId = 4, Type = ConnectionType.Acquintance },
                new HumanConnection { Id = 10, FirstHumanId = 8, SecondHumanId = 10, Type = ConnectionType.Acquintance }
                ); 
                
        }

    }
}

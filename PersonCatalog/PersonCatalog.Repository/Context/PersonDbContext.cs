using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PersonCatalog.Domain.Domains;
using System;


namespace PersonCatalog.Repository.Context
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Relation>()
                .HasKey(e => new { e.PersonFromID, e.PersonToID });

            modelBuilder.Entity<Relation>()
                .HasOne(e => e.PersonFrom)
                .WithMany(e => e.RelativeTo)
                .HasForeignKey(e => e.PersonFromID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Relation>()
                .HasOne(e => e.PersonTo)
                .WithMany(e => e.RelativeFrom)
                .HasForeignKey(e => e.PersonToID);


            modelBuilder.Entity<City>().HasData(
                new City()
                {
                    ID = 1,
                    Name = "tbilisi"
                },
                new City()
                {
                    ID = 2,
                    Name = "batumi"
                });

            modelBuilder.Entity<Person>().HasData(
                new Person()
                {
                    ID = 1,
                    CityID = 1,
                    Name = "rati",
                    Surname = "laitadze",
                    BirthDate = new DateTime(1998, 7, 14),
                    Gender = GenderType.Male,
                    PersonalNumber = "00000000000"
                },
                new Person()
                {
                    ID = 2,
                    CityID = 1,
                    Name = "levani",
                    Surname = "laitadze",
                    BirthDate = new DateTime(1992, 4, 14),
                    Gender = GenderType.Male,
                    PersonalNumber = "00008000001"
                },
                new Person()
                {
                    ID = 3,
                    CityID = 1,
                    Name = "vaxo",
                    Surname = "laitadze",
                    BirthDate = new DateTime(1970, 12, 2),
                    Gender = GenderType.Male,
                    PersonalNumber = "00000000002"
                },
                new Person()
                {
                    ID = 4,
                    CityID = 2,
                    Name = "nana",
                    Surname = "eliava",
                    BirthDate = new DateTime(1970, 5, 18),
                    Gender = GenderType.Female,
                    PersonalNumber = "00000000003"
                });

            modelBuilder.Entity<PhoneNumber>().HasData(
                new PhoneNumber()
                {
                    ID = 1,
                    Number = "000000000",
                    PersonID = 1,
                    phoneNumberType = PhoneNumberType.Mobile
                },
                new PhoneNumber()
                {
                    ID = 2,
                    Number = "0320000000",
                    PersonID = 1,
                    phoneNumberType = PhoneNumberType.Home
                },
                new PhoneNumber()
                {
                    ID = 3,
                    Number = "500000000",
                    PersonID = 2,
                    phoneNumberType = PhoneNumberType.Mobile
                },
                new PhoneNumber()
                {
                    ID = 4,
                    Number = "500000001",
                    PersonID = 3,
                    phoneNumberType = PhoneNumberType.Mobile
                },
                new PhoneNumber()
                {
                    ID = 5,
                    Number = "500000002",
                    PersonID = 4,
                    phoneNumberType = PhoneNumberType.Mobile
                },
                new PhoneNumber()
                {
                    ID = 6,
                    Number = "50000003",
                    PersonID = 4,
                    phoneNumberType = PhoneNumberType.Office
                });


            modelBuilder.Entity<Relation>().HasData(
                new Relation()
                {
                    PersonFromID = 1,
                    PersonToID = 2,
                    RelationType = RelationType.Colleague,
                },
                new Relation()
                {
                    PersonFromID = 1,
                    PersonToID = 3,
                    RelationType = RelationType.Colleague
                },
                new Relation()
                {
                    PersonFromID = 1,
                    PersonToID = 4,
                    RelationType = RelationType.Other
                },
                new Relation()
                {
                    PersonFromID = 2,
                    PersonToID = 4,
                    RelationType = RelationType.Familiar
                },
                new Relation()
                {
                    PersonFromID = 2,
                    PersonToID = 3,
                    RelationType = RelationType.Other
                },
                new Relation()
                {
                    PersonFromID = 3,
                    PersonToID = 4,
                    RelationType = RelationType.Colleague
                });
        }
    }
}

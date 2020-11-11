using Xunit;
using HerosDB.Entities;
using HerosDB.Models;
using HerosDB;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HerosTest.HerosDBTest
{
    public class DBRepoTest
    {
        private readonly IMapper mapper = new DBMapper();
        private DBRepo repo;
        //Test data
        private readonly SuperHero testHero = new SuperHero()
        {
            RealName = "Diana",
            Alias = "Wonder Woman",
            HideOut = "Themyscira",
            SuperPowers = new List<SuperPower>()
            {
                new SuperPower()
                {
                    Name = "Flight",
                    Description = "She can glide through the air on currents in the wind"
                },
                new SuperPower()
                {
                    Name = "Super Abilities",
                    Description = "Superhuman strength, agility, and reflexes"
                }
            }
        };
        private readonly List<Superpeople> testPeople = new List<Superpeople>()
        {
            new Superpeople()
            {
                Realname = "Bob",
                Workname = "Bob the builder",
                Hideout = "The building garage",
                Chartype = 1,
                Powers = new List<Powers>()
                {
                    new Powers()
                    {
                        Name = "Builder Memory",
                        Description = "Never loses his tools, always remembers where they are"
                    },
                    new Powers()
                    {
                        Name = "Super Builder",
                        Description = "If you dream it he can build it"
                    }
                }
            },
            new Superpeople()
            {
                Realname = "Barnabus Saurus III",
                Workname = "Barney",
                Hideout = "This house",
                Chartype = 2
            }
        };
        private readonly List<Charactertype> charactertypes = new List<Charactertype>()
        {
            new Charactertype() { Chartype = "Superhero"},
            new Charactertype() { Chartype = "Supervillain"}
        };
        private void Seed(HeroContext testcontext)
        {
            testcontext.Charactertype.AddRange(charactertypes);
            testcontext.Superpeople.AddRange(testPeople);
            testcontext.SaveChanges();
        }

        [Fact]
        public void AddHeroShouldAdd()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<HeroContext>().UseInMemoryDatabase("AddHeroesShouldAdd").Options;
            using var testContext = new HeroContext(options);
            repo = new DBRepo(testContext, mapper);

            //Act
            repo.AddAHeroAsync(testHero);

            //Assert
            using var assertContext = new HeroContext(options);
            Assert.NotNull(assertContext.Superpeople.Single(h => h.Workname == testHero.Alias));

        }

        [Fact]
        public async void GetHeroesShouldGet()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<HeroContext>().UseInMemoryDatabase("GetHeroesShouldGet").Options;
            using var testContext = new HeroContext(options);
            Seed(testContext);

            //Act
            using var assertContext = new HeroContext(options);
            repo = new DBRepo(assertContext, mapper);
            var result = await repo.GetAllHeroesAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void GetHeroByNameShouldGetHeroByName()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<HeroContext>().UseInMemoryDatabase("GetHeroByNameShouldGetHeroByName").Options;
            using var testContext = new HeroContext(options);
            Seed(testContext);

            //Act 
            using var assertContext = new HeroContext(options);
            repo = new DBRepo(assertContext, mapper);
            var result = repo.GetHeroByName("Bob the builder");

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Bob", result.RealName);
        }
    }
}
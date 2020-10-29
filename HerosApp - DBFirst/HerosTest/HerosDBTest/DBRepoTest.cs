using Xunit;
using HerosDB.Entities;
using HerosDB;
using HerosDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HerosTest.HerosDBTest
{
    public class DBRepoTest
    {
        //Arrange
        private static readonly IMapper mapper = new DBMapper();
        private DBRepo repo;

        private readonly SuperHero testHero = new SuperHero()
        {
            RealName = "Diana",
            Alias = "Wonder Woman",
            HideOut = "Themyscira",
            SuperPowers = new List<SuperPower>(){
                new SuperPower(){
                    Name = "Flight",
                    Description = "She can glide through the air on currents in the wind"
                },
                new SuperPower(){
                    Name = "Superhuman abilities",
                    Description = "Superhuman strength, agility, reflexes"
                }
            }
        };

        private readonly List<Superpeople> testPeople = new List<Superpeople>(){
            new Superpeople()
            {
                Realname = "Bob",
                Workname = "Bob the builder",
                Hideout = "The building garage",
                Chartype = 1
            },
            new Superpeople()
            {
                Realname = "Freddie Jupiter",
                Workname = "Freddie Mercury",
                Hideout = "The Studio",
                Chartype = 2
            }
        };
        private readonly Charactertype heroType = new Charactertype()
        {
            Chartype = "Superhero"
        };
        private readonly Charactertype villainType = new Charactertype()
        {
            Chartype = "Villain"
        };
        [Fact]
        public void AddHeroShouldAddHero()
        {
            //Arrange 
            var options = new DbContextOptionsBuilder<HeroContext>().UseInMemoryDatabase("AddHeroShouldAdd").Options;
            using var testContext = new HeroContext(options);
            repo = new DBRepo(testContext, mapper);

            //Act
            repo.AddAHeroAsync(testHero);

            //Assert
            using var assertContext = new HeroContext(options); //use a new context to make sure that the changes have been implemented, to ensure changes have been implemented to test db
            Assert.NotNull(assertContext.Superpeople.Single(h => h.Workname == testHero.Alias));
        }

        [Fact]
        public async void GetAllHeroesShouldReturnHeroesAsync()
        {
            //Arrange 
            var options = new DbContextOptionsBuilder<HeroContext>().UseInMemoryDatabase("GetAllHeroesShouldReturnHeroes").Options;
            using var testContext = new HeroContext(options);
            Seed(testContext);

            //Act & Assert
            using var assertContext = new HeroContext(options);
            repo = new DBRepo(assertContext, mapper);
            var result = await repo.GetAllHeroesAsync();
            Assert.NotNull(result);

        }

        public void Seed(HeroContext testContext)
        {
            testContext.Charactertype.Add(heroType);
            testContext.Charactertype.Add(villainType);
            testContext.Superpeople.AddRange(testPeople);
            testContext.SaveChanges();
        }

    }
}
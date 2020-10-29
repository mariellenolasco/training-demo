using System.Collections.Generic;
using HerosDB.Entities;
using HerosDB.Models;

namespace HerosDB
{
    public class DBMapper : ISuperHeroMapper, ISuperPowerMapper
    {
        public SuperHero ParseSuperHero(Superpeople hero)
        {
           return new SuperHero(){
                RealName = hero.Realname,
                Alias = hero.Workname,
                HideOut = hero.Hideout,
                SuperPowers = ParseSuperPower(hero.Powers),
                Id = hero.Id
           };
        }

        public Superpeople ParseSuperHero(SuperHero hero)
        {
            return new Superpeople()
            {
                Realname = hero.RealName,
                Workname = hero.Alias,
                Hideout = hero.HideOut,
                Powers = ParseSuperPower(hero.SuperPowers),
                Chartype = 1
            };
        }

        public List<SuperHero> ParseSuperHero(List<Superpeople> hero)
        {
            List<SuperHero> allHeroes = new List<SuperHero>();
            foreach(var h in hero)
            {
                allHeroes.Add(ParseSuperHero(h));
            }
            return allHeroes;
        }

        public SuperPower ParseSuperPower(Powers superPower)
        {
            return new SuperPower(){
                Id = superPower.Id,
                Name = superPower.Name,
                Description = superPower.Description
            };
        }

        public List<SuperPower> ParseSuperPower(ICollection<Powers> superPower)
        {
            List<SuperPower> superPowers = new List<SuperPower>();
            foreach(var power in superPower)
            {
                superPowers.Add(ParseSuperPower(power));
            }
            return superPowers;
        }

        public Powers ParseSuperPower(SuperPower superPower)
        {
            return new Powers(){
                Name = superPower.Name,
                Description = superPower.Description
            };
        }

        public ICollection<Powers> ParseSuperPower(List<SuperPower> superPower)
        {
            ICollection<Powers> powers = new List<Powers>();
            foreach (var power in superPower)
            {
                powers.Add(ParseSuperPower(power));
            }
            return powers;
        }
    }
}
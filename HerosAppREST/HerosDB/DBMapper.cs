using System.Collections.Generic;
using HerosDB.Entities;
using HerosDB.Models;

namespace HerosDB
{
    public class DBMapper : IMapper
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
            foreach (var sp in superPower)
            {
                powers.Add(ParseSuperPower(sp));
            }
            return powers;
        }

        public SuperPower ParseSuperPower(Powers superPower)
        {
            return new SuperPower()
            {
                Name = superPower.Name,
                Description = superPower.Description,
                Id = superPower.Id
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

        public SuperVillain ParseSuperVillain(Superpeople superVillain)
        {
            return new SuperVillain(){
                RealName = superVillain.Realname,
                Alias = superVillain.Workname,
                HideOut = superVillain.Hideout,
                SuperPowers = ParseSuperPower(superVillain.Powers),
                Id = superVillain.Id
           };
        }

        public Superpeople ParseSuperVillain(SuperVillain superVillain)
        {
            return new Superpeople()
            {
                Realname = superVillain.RealName,
                Workname = superVillain.Alias,
                Hideout = superVillain.HideOut,
                Powers = ParseSuperPower(superVillain.SuperPowers),
                Chartype = 2
            };
        }

        public List<SuperVillain> ParseSuperVillain(List<Superpeople> superVillain)
        {
            List<SuperVillain> allVillains = new List<SuperVillain>();
            foreach(var v in superVillain)
            {
                allVillains.Add(ParseSuperVillain(v));
            }
            return allVillains;
        }
    }
}
using HerosDB.Models;
using HerosDB.Entities;
using System.Collections.Generic;
namespace HerosDB
{
    public interface ISuperHeroMapper
    {
         SuperHero ParseSuperHero(Superpeople hero);
         Superpeople ParseSuperHero (SuperHero hero);
         List<SuperHero> ParseSuperHero(List<Superpeople> hero);
    }
}
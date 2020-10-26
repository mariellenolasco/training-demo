using System.Collections.Generic;
namespace HerosDB.Models
{
    public class SuperVillain:SuperPerson
    {
        public List<SuperHero> Nemesis { get; set; }
    }
}
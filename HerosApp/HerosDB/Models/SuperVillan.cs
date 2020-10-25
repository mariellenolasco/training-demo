using System.Collections.Generic;
namespace HerosDB.Models
{
    public class SuperVillan:SuperPerson
    {
        public List<SuperHero> Nemesis { get; set; }
    }
}
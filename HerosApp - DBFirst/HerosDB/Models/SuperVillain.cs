using System.Collections.Generic;
namespace HerosDB.Models
{
    public class SuperVillain:SuperPerson
    {
        public List<Enemies> Nemesis { get; set; }
    }
}
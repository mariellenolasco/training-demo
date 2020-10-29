using System.Collections.Generic;

namespace HerosDB.Models
{
    public class SuperPerson
    {
     public int Id{get; set;}
     public string RealName{get;set;}
     public string Alias { get; set; }
     public string HideOut {get; set;}
     public List<SuperPower> SuperPowers { get; set; }

    }
}
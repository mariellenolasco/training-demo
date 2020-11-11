using HerosDB.Models;
using HerosDB.Entities;
using System.Collections.Generic;
namespace HerosDB
{
    public interface ISuperPowerMapper
    {
         SuperPower ParseSuperPower(Powers superPower);
         List<SuperPower> ParseSuperPower(ICollection<Powers> superPower);
         Powers ParseSuperPower(SuperPower superPower);
         ICollection<Powers> ParseSuperPower(List<SuperPower> superPower);
    }
}
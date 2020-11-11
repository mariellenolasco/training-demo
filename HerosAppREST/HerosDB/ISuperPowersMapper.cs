using HerosDB.Entities;
using HerosDB.Models;
using System.Collections.Generic;
namespace HerosDB
{
    public interface ISuperPowersMapper
    {
        Powers ParseSuperPower(SuperPower superPower);
        ICollection<Powers> ParseSuperPower(List<SuperPower> superPower);
        SuperPower ParseSuperPower(Powers superPower);
        List<SuperPower> ParseSuperPower(ICollection<Powers> superPower);
    }
}
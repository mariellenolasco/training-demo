using HerosDB.Models;
using HerosDB.Entities;
using System.Collections.Generic;
namespace HerosDB
{
    public interface ISuperVillainMapper
    {
        SuperVillain ParseSuperVillain(Superpeople superVillain);
        Superpeople ParseSuperVillain(SuperVillain superVillain);
        List<SuperVillain> ParseSuperVillain(List<Superpeople> superVillain);
    }
}
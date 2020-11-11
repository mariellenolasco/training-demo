using HerosDB.Models;
using System.Collections.Generic;
namespace HerosDB
{
    public interface IVillainRepo
    {
        void AddAVillain(SuperVillain superVillain);
        List<SuperVillain> GetAllVillains();

        SuperVillain GetVillainByName(string name);

    }
}
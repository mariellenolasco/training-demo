using HerosDB.Models;
using HerosDB;
using System.Collections.Generic;
using System;

namespace HerosLib
{
    public class VillainService
    {
        private IVillainRepo repo;
        public VillainService(IVillainRepo repo)
        {
            this.repo = repo;
        }

        public void AddVillain(SuperVillain newVillain)
        {
            //Add some business logic here
            repo.AddAVillain(newVillain);
        }
        public List<SuperVillain> GetAllVillains()
        {
            return repo.GetAllVillains();
        }
        public SuperVillain GetVillainByName()
        {
            throw new NotImplementedException();
        }
    }
}
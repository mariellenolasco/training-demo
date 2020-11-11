using System.Collections.Generic;
using HerosDB.Models;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
namespace HerosDB
{
    public class FileRepo : ISuperHeroRepo, IVillainRepo
    {
        private string filename = "HerosDB/Heroes/Heroes.txt";
        public async void AddAHeroAsync(SuperHero hero)
        {
            using (FileStream fs = File.Create(path: filename)){
                await JsonSerializer.SerializeAsync(fs, hero);
                System.Console.WriteLine("Hero being written to file");
            }

        }

        public void AddAVillain(SuperVillain superVillain)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<SuperHero>> GetAllHeroesAsync()
        {
            List<SuperHero> allHeroes = new List<SuperHero>();
            using (FileStream fs = File.OpenRead(filename))
            {
                allHeroes.Add(await JsonSerializer.DeserializeAsync<SuperHero>(fs));
            }
            return allHeroes;

        }

        public List<SuperVillain> GetAllVillains()
        {
            throw new System.NotImplementedException();
        }

        public SuperHero GetHeroByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public SuperVillain GetVillainByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System;
using HerosLib.Models;
using HerosDB;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace HeroUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string option;
            do{
                Console.WriteLine("Hello Friend! Welcome to the tour of heros app");
                Console.WriteLine("[0] Create a hero \n[1] Get all heroes");
                option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Hero hero = GetHeroDetails();
                        Console.WriteLine("Hero created!");
                        Console.WriteLine($"Name: {hero.HeroName} \nSuper power: {hero.SuperPowers}");
                        break;
                    case "1":
                        IRepository repo = new FileRepo();
                        Task<List<Hero>> getHeroTask = repo.GetAllHeroesAsync();
                        List<Hero> allHeros = getHeroTask.Result;
                        foreach (var item in allHeros)
                        {
                            Console.WriteLine($"Name: {item.HeroName} \nSuper power: {item.SuperPowers}");
                        }
                        break;
                }
            }while(!option.Equals("0") || !option.Equals("1"));
            

        }

        static Hero GetHeroDetails(){
            Hero hero = new Hero();
            Console.Write("Enter Hero Name: ");
            hero.HeroName = Console.ReadLine();
            Console.Write("Enter Hero Superpower: ");
            hero.SuperPowers = Console.ReadLine();
            IRepository repo = new FileRepo();
            repo.AddAHeroAsync(hero);
            return hero;
        }
    }
}

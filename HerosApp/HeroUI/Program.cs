using System;
using HerosDB.Models;
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
                        SuperHero hero = GetHeroDetails();
                        Console.WriteLine("Hero created!");
                        Console.WriteLine($"Name: {hero.Alias} \nSuper power: {hero.SuperPowers}");
                        break;
                    case "1":
                        ISuperHeroRepo repo = new FileRepo();
                        Task<List<SuperHero>> getHeroTask = repo.GetAllHeroesAsync();
                        List<SuperHero> allHeros = getHeroTask.Result;
                        foreach (var item in allHeros)
                        {
                            Console.WriteLine($"Name: {item.Alias} \nSuper power: {item.SuperPowers}");
                        }
                        break;
                }
            }while(!option.Equals("0") || !option.Equals("1"));
            

        }

        static SuperHero GetHeroDetails(){
            SuperHero hero = new SuperHero();
            Console.Write("Enter Hero Name: ");
            hero.Alias = Console.ReadLine();
            Console.Write("Enter Hero Superpower: ");
            //hero.SuperPowers = Console.ReadLine();
            ISuperHeroRepo repo = new FileRepo();
            repo.AddAHeroAsync(hero);
            return hero;
        }
    }
}

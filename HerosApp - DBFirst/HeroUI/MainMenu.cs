using System;
using HerosDB;
using Microsoft.EntityFrameworkCore;
using HerosDB.Entities;
namespace HeroUI
{
    public class MainMenu : IMenu
    {
        private string userInput;
        private HeroContext context = new HeroContext();
        private HeroMenu heroMenu;

        public MainMenu()
        {
            this.heroMenu = new HeroMenu(new DBRepo(context, new DBMapper()), new MessagingService());
        }
        
        public void start()
        {
            do{
                Console.WriteLine("Welcome Friend! Are you a hero or a villain?");
                Console.WriteLine("[0] Hero?");
                Console.WriteLine("[1] Villain?");
                Console.WriteLine("[2] Exit?");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        //call the hero menu;
                        heroMenu.start();
                        break;
                    case "1":
                        //call the villain menu;
                        break;
                    case "2":
                        Console.WriteLine("Goodbye Friend");
                        break;
                    default:
                    //call the invalid message
                    break;
                }

            }while(!userInput.Equals("2"));
        }
    }
}
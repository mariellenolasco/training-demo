using HerosDB;
using System;
using HerosDB.Models;
using System.Collections.Generic;
namespace HeroUI
{
    public class VillainMenu : IMenu
    {
        private string userInput;
        private IVillainRepo repo;
        private IMessagingService service;
        private IMenu main;
        public VillainMenu(IVillainRepo repo, IMessagingService service, IMenu main){
            this.repo = repo;
            this.service = service;
            this.main = main;
        }
        public void start()
        {
            do{
                Console.WriteLine("Welcome Villain! What would you like to do?");
                Console.WriteLine("[0] Create a Villain?");
                Console.WriteLine("[1] Get all Villains?");
                Console.WriteLine("[2] Create some chaos?");
                Console.WriteLine("[3] Go back to the main menu?");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        //call create a villain, call get villain details
                        SuperVillain newVillain = GetVillainDetails();
                        break;
                    case "1":
                        //call get all villains
                        break;
                    case "2":
                        //call the event delegate for villain work, call get villain by name
                        break;
                    case "3":
                        //call the main menu
                        main.start();
                        break;
                    default:
                        //invalid input message;
                        service.InvalidInputMessage();
                        break;
                }
            }while(!userInput.Equals("3"));
        }
        public SuperVillain GetVillainDetails()
        {
            SuperVillain villain = new SuperVillain();
            List<SuperPower> superPowers = new List<SuperPower>();
            Console.Write("Enter Villain Name: ");
            villain.Alias = Console.ReadLine();
            Console.Write("Enter Villain's Real Name: ");
            villain.RealName = Console.ReadLine();
            Console.Write("Enter Villain Hideout: ");
            villain.HideOut = Console.ReadLine();
            do{
                SuperPower superPower = new SuperPower();
                Console.WriteLine("Enter Villain's Superpowers (type end to stop): ");
                Console.Write("Enter Super Power Name:");
                superPower.Name = Console.ReadLine();
                if(superPower.Name.Equals("end")) break;
                Console.Write("Enter Super Power Description:");
                superPower.Description = Console.ReadLine();
                superPowers.Add(superPower);
            }while(true);
            villain.SuperPowers = superPowers;
            //needs code to get all the villains and add them as a villain to the hero
            return villain;
        }
    }
}
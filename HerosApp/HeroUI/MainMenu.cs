using System;
namespace HeroUI
{
    public class MainMenu : IMenu
    {
        private string userInput;
        private HeroMenu heroMenu;
        public MainMenu(HeroMenu heroMenu)
        {
            this.heroMenu = heroMenu;
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
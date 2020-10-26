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
            IMenu main = new MainMenu();
            main.start();
        }

    }
}

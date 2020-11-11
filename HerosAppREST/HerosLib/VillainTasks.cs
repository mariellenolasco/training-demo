using System;
using System.Threading;
namespace HerosLib
{
    public class VillainTasks
    {
        public void CreateChaos()
        {
            Console.WriteLine("Chaos has been made");
        }
        public void PlanWorldDomination()
        {
            Console.WriteLine("Planning world domination");
            for(int i = 0; i < 10; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Plans complete");
        }
    }
}
using System;
using System.Threading.Tasks;

namespace HerosLib
{
    public delegate void HeroDel(); 
    public class HeroTasks : IHeroOperations, IHeroSuperPowers
    {
        string path=@"HerosLib\SuperPowers.txt";
        public event HeroDel workDone;
        public async void DoWork(){
            Console.WriteLine("Work Started.....");
            await Task.Run(new Action(GetPowers));// create a new thread and returns to the main thread whenever finishes the task
            Console.WriteLine("Saving humanity is my work");
            Console.WriteLine("Work finished");
            OnWorkDone();// event call to notify all subscribers
        }
        /// <summary>
        /// check if event is binded to the handlers
        /// </summary>
        public void OnWorkDone(){
            if(workDone!=null){
                workDone();// raising the event 
            }
        }
        public void ManageLife(){
            Console.WriteLine("I have a cranky partner to manage");
        }
        public void GetPowers(){
            Console.WriteLine("Getting Powers");
            System.Threading.Thread.Sleep(2000);
            string superPower=System.IO.File.ReadAllText(path);
            Console.WriteLine($"Power obtained {superPower}");
        }
    }
}
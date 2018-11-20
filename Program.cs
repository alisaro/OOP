//Project Computer v.13
//static members and methods

using System;
using System.Collections.Generic;

namespace OOP_in_Csharp
{
    class Program
    {
        public static void Main(string[] args)
        {

            List<Computer> network = new List<Computer>();

            Server omega = new Server("Server1", "Dell", "Linux", false, "WEB Server", "10.0.0.10");


            //Creating the object mySecondComp using the defined constructer
            Computer myComp = new Computer("Angel", "Dell", "Windows", false);
            Computer mySecondComp = new Computer("Alicia", "Lenovo", "Linux", false);
            Computer myThirdComp = new Computer("Alberto", "HP", "Windows", false);
            Computer myFourthComp = new Computer("Andrzej", "Dell", "Windows", false);
            //

            network.Add(omega);
            network.Add(myComp);
            network.Add(mySecondComp);
            network.Add(myThirdComp);
            network.Add(myFourthComp);

            for (int i = 0; i < network.Count; i++)
            {
                network[i].StartComputer();
            }
            //

            Console.WriteLine("----------------------------------------------------------------");


            int compsInNetwork = Computer.CountComps();

            Console.WriteLine("----------------------------------------------------------------");

            Computer.ShowComputer(network);

            omega.ShutDownComputer();
            //mySecondComp.ShutDownComputer();


            //Homeworks
            int compsON = Computer.CountCompsON();

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("We have {0} computers ON.", compsON);
            Console.WriteLine("----------------------------------------------------------------");


            Computer.ShowComputer(network);


            Computer.PingToComputer(network, myComp, "10.0.0.14");

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("We have {0} computers in our network.", compsInNetwork);

        }
    }

}

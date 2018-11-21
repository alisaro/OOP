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

            //Creating the object myComp using the default constructer
            Computer myComp = new Computer("Angel", "Dell", "Windows", false);

            //myComp.Ipadress = "10.0.0.20";
            //myComp.Make = "Lenovo";
            //myComp.OperatingSystem = "Windows";

            //Creating the object mySecondComp using the defined constructer
            Computer mySecondComp = new Computer("Alicia", "Lenovo", "Linux", false);
            Computer myThirdComp = new Computer("Alberto", "HP", "Windows", false);
            Computer myFourthComp = new Computer("Andrzej", "Dell", "Windows", false);
            //

            network.Add(omega);
            network.Add(myComp);
            network.Add(mySecondComp);
            network.Add(myThirdComp);
            network.Add(myFourthComp);

            //myComp.StartComputer();
            //myComp.StartComputer();
            //mySecondComp.StartComputer();

            for (int i = 0; i < network.Count; i++)
            {
                network[i].StartDevice();
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


            Computer.PingToComputer(network, myComp, "10.0.0.22");





            //string ip="10.0.0.22";

            //Computer computer = myComp;
            //Computer computer = mySecondComp;
            //Computer computer = myThirdComp;
            //Computer computer = myFourthComp;


            //int j;
            /*
            if(computer.SwitchOn ==true){
                j = computer.Find(ip, network);
                 if((j!=1) || (computer.Ipadress == ip)){
                 Console.WriteLine("From {0} icmp_seq=2 Destination Host Unreachable", computer.Ipadress);
                 }
            }
            else{
                Console.WriteLine("From {0} icmp_seq=2 Destination Host Unreachable", computer.Ipadress);
            }
            */

            Console.WriteLine("----------------------------------------------------------------");

            Console.WriteLine("We have {0} computers in our network.", compsInNetwork);

        }
    }
}


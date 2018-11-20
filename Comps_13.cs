//Project Computer v.13
//static members and methods

using System;
using System.Collections.Generic;

namespace OOP_in_Csharp
{
    public interface IDevice
    {
        // interface members
        void StartComputer();
        void ShutDownComputer();
    }
    //----------------------------    
    public class Computer : IDevice
    {


        public Computer(string name, string make, string age, bool switchOn)
        {
            this.Name = name;
            this.Make = make;
            this.OperatingSystem = age;
            this.SwitchOn = switchOn;

            compCounter++;

        }


        public Computer()
        {
            compCounter++;
        }

        // private member variables
        protected string _name;
        protected string _ipadress;
        protected bool _switchOn;
        protected string _make;
        protected string _operatingSystem;

        protected static int compCounter = 0;
        protected static int compON = 0;
        protected static int compsInNetwork = 10;

        public static int CountComps()
        {
            return compCounter;
        }

        //Homeworks
        public static int CountCompsON()
        {
            return compON;
        }

        //

        //22-10-18
        public virtual void StartComputer()
        {

            if (SwitchOn == false)
            {
                this.SwitchOn = true;
                compON++;
                this.Ipadress = GetIpAddress();
                Console.WriteLine("The comp {0} is starting", this.Ipadress);
            }
            else
            {
                Console.WriteLine("The comp {0} is already start ", this.Ipadress);
            }

        }


        public static void ShowComputer(List<Computer> network)
        {
            foreach (Computer comp in network)
            {
                if (comp.SwitchOn)
                {
                    Type type = comp.GetType();
                    string stringType = type.ToString();
                    Console.Write("{0}\t\t{1}\t\t{2}\t\t{3}\t", comp.Name, comp.Ipadress, comp.OperatingSystem, comp.Make);
                    int pos = stringType.IndexOf('.');
                    //Console.Write(stringType.Substring(pos + 1, 4));

                    if (stringType.Substring(pos + 1, 4) == "Serv")
                    {
                        Server serv = (Server)comp; //casting of the type Server on type Computer 
                        System.Console.WriteLine("\t{0}", serv.Destination);
                    }
                    else
                        Console.WriteLine();


                    //Console.WriteLine(comp.GetType());
                }
            }

            Console.WriteLine("----------------------------------------------------------------");
        }


        //5-11-18
        public string GetIpAddress()
        {
            string address = "10.0.0." + (++compsInNetwork).ToString();
            return address;
        }



        public virtual void ShutDownComputer()
        {
            if (SwitchOn == true)
            {
                this.SwitchOn = false;
                compON--;
                Console.WriteLine("The comp {0} is shuting down", this.Ipadress);
            }
            else
            {
                Console.WriteLine("The comp {0} is already shut down", this.Ipadress);
            }

        }


        public static void PingToComputer(List<Computer> network, Computer pingFrom, string pingTo)
        {
            Random rnd = new Random();
            double answer;
            Computer myComp = pingFrom;
            bool found = false;
            Console.WriteLine("\nTrying to ping from the machine{0}({1}) to {2}.", myComp.Name, myComp.Ipadress, pingTo);
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (Computer comp in network)
            {
                if ((pingTo == comp.Ipadress) && (comp.SwitchOn == true))
                {
                    found = true;
                    break;
                }
            } // the end of the loop
            if (found)
            {
                for (int i = 5; i < 15; i++)
                {
                    answer = (float)(rnd.Next(1, 100)) / 100;
                    Console.WriteLine("64 bytes from {0} icmp_seq={1} ttl=64 time={2} ms", myComp.Ipadress, i.ToString(), answer.ToString());
                }
            }
            else
            {
                Console.WriteLine("Adress {0} not found !!! ", pingTo);
            }
        } //end of PingToComputer method
          /*
          public int Find(string ip, List<Computer> network){
                int j=0;
                for(int i=0; i<network.Count; i++){
                    if((network[i].Ipadress == ip) && (network[i].SwitchOn == true)){
                        j=1;

                    }
                }

                if(j==1){
                     Console.WriteLine("64 bytes from {0} : icmp_seq=2 ttl=64 time=0.995 ms", ip);
                }

                return j;
            } 
          */
          // public properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Ipadress
        {
            get { return _ipadress; }
            set { _ipadress = value; }
        }

        public string Make
        {
            get { return _make; }
            set { _make = value; }
        }

        public string OperatingSystem
        {
            get { return _operatingSystem; }
            set { _operatingSystem = value; }
        }


        //
        public bool SwitchOn
        {
            get { return _switchOn; }
            set { _switchOn = value; }
        }
        //

    }



    //---------------------------------------------------------------------------------------------------------------------



    public class Server : Computer
    {
        public Server(string name, string make, string osystem, bool switched, string dest, string ip) : base(name, make, osystem, switched)
        {
            this.Destination = dest;
            this.Ipadress = ip;

        }

        // private member variables
        protected string _destination;

        // public properties
        public string Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }

        public override void StartComputer()
        {
            if (SwitchOn == false)
            {
                this.SwitchOn = true;
                compON++;
                Console.WriteLine("The comp {0} is starting", this.Ipadress);
            }
            //else{
            //    Console.WriteLine("The server {0} is already start ", this.Ipadress);
            //}

        }

        public override void ShutDownComputer()
        {
            Console.WriteLine("****************** ||| *********************");
            Console.WriteLine("You want to shut down this server.Are you sure? (y/n): ");

            string confirm = Console.ReadLine();
            if (confirm == "y")
            {
                this.SwitchOn = false;
                compON--;
                Console.WriteLine("The comp {0} is shuting down", this.Ipadress);
            }
        }




    }

    
}




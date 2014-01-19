using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTester
{
    class Program
    {
        static void Main(string[] args)
        {

            MySuperComponent.MySuperClass component = new MySuperComponent.MySuperClass();
            MySuperEvent.IMyEvent ev = new MySuperEvent.MyEventClass() as MySuperEvent.IMyEvent;
            string s;
            do
            {
                s = Console.ReadLine();
                ev.TheEvent(s);
                Console.WriteLine(component.UpperCase(s));
                
            } while (s != "END");


        }
    }
}

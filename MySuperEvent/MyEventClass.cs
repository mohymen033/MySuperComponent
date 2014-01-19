using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace MySuperEvent
{
    [Guid("BD40FDD7-42A3-44A4-8A17-8748123E3E5D")]
    public interface IMyEvent
    {
        void TheEvent(string s);
        
    }


    [EventClass]
    [Guid("203AF033-C4ED-403D-8E6B-12C7F2310916")]
    public class MyEventClass : ServicedComponent, IMyEvent
    {
        public static string FiringInterfaceID = "{BD40FDD7-42A3-44A4-8A17-8748123E3E5D}";
        public static string EventClassCLSID = "{203AF033-C4ED-403D-8E6B-12C7F2310916}";

        public void TheEvent(string s)
        {
          
        }

       
    }

}

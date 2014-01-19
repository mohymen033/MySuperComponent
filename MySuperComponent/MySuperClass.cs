using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.EnterpriseServices;

namespace MySuperComponent
{
    [Description("This is my super class")]
    public class MySuperClass : ServicedComponent, IMySuperInterface
    {
        [Description("Very useful method")]
        public string UpperCase(string s)
        {
           
           
                string s1 = s.ToUpper();
                return s1;
           
        }
    }

    public interface IMySuperInterface
    {
        string UpperCase(string s);
    }


}

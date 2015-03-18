using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace MobilePhone
{


    public class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            GSMTest.LoadPhones();
            GSMTest.PrintTest();

            GSMCallHistoryTest.Test();          
        }
    }
}

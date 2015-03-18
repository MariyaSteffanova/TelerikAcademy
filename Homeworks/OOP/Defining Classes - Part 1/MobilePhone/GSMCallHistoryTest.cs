using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    class GSMCallHistoryTest
    {
        public static GSM testPhone = GSM.IPhone4S;
        public static void Test()
        {
            //testPhone.AddCalls();
            //testPhone.AddCalls();
            //testPhone.AddCalls();
            Console.WriteLine("CALL HISTORY");
            testPhone.Print();
            decimal price = testPhone.CallsPrice();
            Console.WriteLine("Price for calls: {0:F4}", price);

            Console.WriteLine(new string('-', 33));
            Console.WriteLine("CALL HISTORY: after removing longest call");
            testPhone.DeleteCalls();
            testPhone.Print();
            price = testPhone.CallsPrice();
            Console.WriteLine("Price for calls: {0:F4}", price);

            Console.WriteLine(new string('-', 33));
            Console.WriteLine("CLEARING CALL HISTORY");
            testPhone.ClearCallHistory();
            testPhone.Print();
            testPhone.Print();
            price = testPhone.CallsPrice();
            Console.WriteLine("Price: {0:F4}", price);
        }
    }
}

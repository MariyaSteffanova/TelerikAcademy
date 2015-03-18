using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    class GSMTest
    {
        static List<GSM> list = new List<GSM>();
        public static List<GSM> LoadPhones()
        {
            
            GSM iPhone4S = GSM.IPhone4S;
            GSM samsungGalaxyS6 = new GSM("Samsung Galaxy S6 edge", "Samsung", "", 899.99M, new Battery("Li-Ion", 17M, 0M, BatteryType.NiMH), new Display(5.1M, "16 M"));
            list.Add(iPhone4S);
            list.Add(samsungGalaxyS6);

            return list;
        }
        public static void PrintTest()
        {
            foreach (var phone in list)
            {
                Console.WriteLine(phone.ToString());
            }
        }

    }
}

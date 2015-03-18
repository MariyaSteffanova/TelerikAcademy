using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    public class Calls
    {
        private DateTime date;

        private string dialledNumber;
        private int duration;

        public Calls(DateTime dateTime, string dialledNumber, int duration)
        {
            this.date = dateTime;
            this.dialledNumber = dialledNumber;
            this.duration = duration;
        }
        // may need Property
        public int Duration
        {
            get { return this.duration; }
        }
        public static List<Calls> LoadCalls()
        {
            List<Calls> listCalls = new List<Calls>();
            listCalls.Add(new Calls(DateTime.Now, "0889101010", 30));
            listCalls.Add(new Calls(DateTime.Now.AddDays(-2).AddHours(2), "0888202020", 40));
            listCalls.Add(new Calls(DateTime.Now.AddDays(-1), "0887303030", 54));

            return listCalls;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Date: {0:dd.MM.yy}", this.date));
            sb.AppendLine(string.Format("Time: {0:hh:mm:ss}", this.date));
            sb.AppendLine("Dialled number: " + this.dialledNumber);
            sb.AppendLine("Duration: " + duration);
            return sb.ToString();
        }

    }
}

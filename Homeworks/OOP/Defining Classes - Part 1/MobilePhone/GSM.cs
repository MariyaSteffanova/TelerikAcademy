using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    public class GSM
    {
        private const decimal pricePerMinute = 0.21M;

        private string model;
        private string manufacturer;
        private string owner;
        private decimal price;
        private Battery battery;
        private Display display;
        private List<Calls> callHistory;


        private static GSM iPhone4S = new GSM("IPhone4S", "Apple", "", 999.99M, new Battery("Li-Po", 14M, 0M, BatteryType.NiMH), new Display(3.5M, "16 M"));
        public GSM()
        {

        }
        public GSM(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
        }
        public GSM(string model, string manufacturer, string owner, decimal price, Battery battery, Display display)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.owner = owner;
            this.price = price;
            this.PhoneBattery = battery;
            this.PhoneDisplay = display;
        }
        public static GSM IPhone4S
        {
            get { return iPhone4S; }
            private set { value = iPhone4S; }

        }
        public string Model                     // equels to: public string Model{ get; set;}                                                    
        {                                       // Note that I will use this way of creating constructors :)
            get { return this.model; }
            set
            {
                if (value == string.Empty) throw new ArgumentException("String can not be empty!");
                else this.model = value;
            }
        }
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set 
            {
                if (value == string.Empty) throw new ArgumentException("String can not be empty!");
                else this.manufacturer = value; 
            }
        }
        public string Owner
        {
            get { return this.owner; }
            set
            {
                if (value == string.Empty) throw new ArgumentException("String can not be empty!");
                else this.model = value;
            }
        }
        public decimal Price
        {
            get { return this.price; }
            set 
            {
                if (value < 0) throw new ArgumentException("Price can not be negative value");
                else  this.price = value; 
            }
        }
        public Battery PhoneBattery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }
        public Display PhoneDisplay
        {
            get { return this.display; }
            set { this.display = value; }
        }
        public List<Calls> CallHistory
        {
            get
            {
                if (this.callHistory == null)
                {
                    this.callHistory = Calls.LoadCalls();
                }
                return this.callHistory;
            }
        }
        public void AddCalls()
        {
            var randomGenerator = new Random();
            var newCall = new Calls(DateTime.Now.AddHours(randomGenerator.Next(-5, -1)), "0889151515", randomGenerator.Next(1, 54));
            this.callHistory.Add(newCall);
        }
        public void DeleteCalls()
        {
            var longest = this.CallHistory.OrderBy(x => x.Duration).Last();
            this.callHistory.Remove(longest);
        }
        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }
        public decimal CallsPrice()
        {
            decimal price = 0.0M;

            foreach (var call in this.callHistory)
            {
                price += call.Duration;
            }
            price /= 60;
            price *= pricePerMinute;
            return price;
        }
        public void Print()
        {
            foreach (var call in this.CallHistory)
            {
                Console.WriteLine(call);
            }

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Model");
            sb.Append(string.Format(":{0,-10}\n", this.Model));
            sb.Append("Manufacturer");
            sb.Append(string.Format(":{0,-10}\n", this.Manufacturer));
            sb.Append("Battery Type");
            sb.Append(string.Format(":{0,-10}\n", this.PhoneBattery.Type));
            sb.Append("Hours Idle");
            sb.Append(string.Format(":{0,-10}\n", this.PhoneBattery.HoursIdle));
            sb.Append("Hours Talk");
            sb.Append(string.Format(":{0,-10}\n", this.PhoneBattery.HoursTalk));
            sb.Append("Display size");
            sb.Append(string.Format(":{0,-10}\n", this.PhoneDisplay.DisplaySize));
            sb.Append("Display colors");
            sb.Append(string.Format(":{0,-10}\n", this.PhoneDisplay.DisplayColors));
            sb.Append("Price");
            sb.Append(string.Format(":{0,-10}\n", this.Price));



            return sb.ToString();
        }
    }
}

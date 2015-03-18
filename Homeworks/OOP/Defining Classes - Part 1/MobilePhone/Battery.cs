using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    public class Battery
    {
        private string model;
        private decimal hoursIdle;
        private decimal hoursTalk;
        private BatteryType type;

        public Battery() 
        {
            this.model = "";
            this.HoursIdle = 0.0M;
            this.hoursTalk = 0.0M;

        }
        public Battery(string model, decimal hoursIdle, decimal hoursTalk, BatteryType type)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.Type = type;
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public decimal HoursIdle { get; set; }
        public decimal HoursTalk { get; set; }
        public BatteryType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }



    }
    public enum BatteryType
    {
        NiMH, NiCd //Li-Ion
    }
}

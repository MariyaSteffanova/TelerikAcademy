using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
   public class Display
    {
        private decimal size;
        private string numberOfColors;

        public Display() { }
        public Display(decimal size, string numberOfColors)
        {
            this.size = size;
            this.numberOfColors = numberOfColors;
        }
        public decimal DisplaySize
        {
            get {return this.size; }
            set 
            {
                if (value < 1) throw new ArgumentException("Size can not be 0 or less.");
                else this.size = value; 
            }
        }
        public string DisplayColors
        {
            get { return this.numberOfColors; }
            set 
            {
                if (int.Parse(value) < 2) throw new ArgumentException("Colors can be only more than 2 (black and white)");
                else this.numberOfColors = value; 
            }
        }

    }
}

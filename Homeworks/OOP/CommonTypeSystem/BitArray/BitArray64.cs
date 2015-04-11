namespace BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    public class BitArray64 : IEnumerable<int>
    {
        private string binaryNum;
       
        public BitArray64(ulong number)
        {
            this.binaryNum = ConvertToBinary(number);
            this.DecimalRepresentation = number;
        }
        private ulong decimalRepresentation;

        public ulong DecimalRepresentation
        {
            get { return decimalRepresentation; }
            set { decimalRepresentation = value; }
        }

        private string ConvertToBinary(ulong number)
        {
            ulong temp = number;
            var binary = new List<int>();
            var binaryNumber = new ulong();
            while (Math.Abs((double)temp) > 0)
            {
                binaryNumber = temp % 2;
                binary.Add((int)binaryNumber);
                temp /= 2;
            }
            binary.Reverse();
            if (number == 0) return "0";
            return string.Join("", binary);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var digit in this.binaryNum)
            {
                sb.Append(digit);
            }
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            var compareNum = obj as BitArray64;
            if (this.binaryNum.Equals(compareNum.binaryNum))
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode()*Convert.ToInt32(this.binaryNum);
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !first.Equals(second);
        }

        public int this[int index]
        {
            get {
                
                return this.binaryNum[index];}
            //set {this.binaryNum[index]  = value ;}
        }

        public IEnumerator<int> GetEnumerator()
        {

            foreach (var item in binaryNum)
            {
               yield return item;
            }
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

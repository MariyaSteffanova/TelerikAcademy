using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderSubstring
{
   public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int lenght)
        {
            var newSb = new StringBuilder();

            for (int i = 0 ; i < lenght ; i++)
            {
                newSb.Append(sb[i+index]);
            }

            return newSb;        
        }
    }
}

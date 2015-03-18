namespace StringBuilderSubstring
{
    using System;
    using System.Text;

    public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int lenght)
        {
            var newSb = new StringBuilder();
            for (int i = 0; i < lenght; i++)
            {
                newSb.Append(sb[i + index]);
            }

            return newSb;
        }
    }
}

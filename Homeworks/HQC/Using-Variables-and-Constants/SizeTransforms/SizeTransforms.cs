namespace SizeTransforms
{
    using System;

    public class SizeTransforms
    {
        public static void Main()
        {
            var size = new Size(10.0, 20.0);
            var rotatedSize = size.GetRotatedSize(90);

            Console.WriteLine(size);
            Console.WriteLine(rotatedSize);
        }
    }
}

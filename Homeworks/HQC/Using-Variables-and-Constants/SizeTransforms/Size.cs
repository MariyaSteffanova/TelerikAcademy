namespace SizeTransforms
{
    using System;

    public class Size
    {
        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public Size GetRotatedSize(double angleOfRotation)
        {            
            double angleCos = Math.Abs(Math.Cos(angleOfRotation));
            double angleSin = Math.Abs(Math.Sin(angleOfRotation));

            double newWidth = (angleCos * this.Width) + (angleSin * this.Height);
            double newHeight = (angleSin * this.Width) + (angleCos * this.Height);

            Size rotatedSize = new Size(newWidth, newHeight);

            return rotatedSize;
        }

        public override string ToString()
        {
            return string.Format("Width: {0:F2}, Height: {1:F2}", this.Width, this.Height);
        }
    }
}

namespace Shapes
{
    using System;

   public abstract class Shape
    {
       private decimal width;

       private decimal height;
       
       protected decimal Width
       {
           get { return this.width; }
           set 
           {
               if (value < 0) { throw new ArgumentException("The width cannot be less than zero!"); }
               this.width = value; 
           }
       }

       protected decimal Height
       {
           get { return this.height; }
           set
           {
               if (value < 0) { throw new ArgumentException("The height cannot be less than zero!"); }
               this.height = value;
           }
       }
              
       public abstract decimal CalculateSurface();
    }
}

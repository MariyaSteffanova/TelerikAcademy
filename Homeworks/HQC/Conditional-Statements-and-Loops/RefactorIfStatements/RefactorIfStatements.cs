namespace RefactorIfStatements
{
    using System;
    using Cooking.Ingredients;

    public class RefactorIfStatements
    {
        private const int MinX = 1;
        private const int MaxX = 42;
        private const int MinY = 1;
        private const int MaxY = 42;

        public static void Main()
        {
            Potato potato = new Potato();

            //   Potato constructor set IsPeeled to false by default, so it won't be cooked. 
            //    If you want cooked potato uncomment the next line (or cook some by yourself, it's easy)

            //  potato.Peel();  

            if (potato != null)
            {
                if (potato.IsPeeled && !potato.IsRotten)
                {
                    potato.Cook();
                }
            }

            Console.WriteLine(potato);

            //    if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
            //    {
            //       VisitCell();
            //    }  

            int x = 9;
            int y = 11;
            bool shouldVisitCell = true;

            if (IsInRange(x, MinX, MaxX) && IsInRange(y, MinY, MaxY) && shouldVisitCell)
            {
                VisitCell();
            }
        }

        public static void VisitCell()
        {
            Console.WriteLine("Cell visited");
        }

        public static bool IsInRange(int value, int min, int max)
        {
            if (min < value && value < max)
            {
                return true;
            }

            return false;
        }
    }
}

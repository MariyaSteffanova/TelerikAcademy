namespace Methods
{
    public class PositionChecker
    {
        public static bool IsHorizontal(double y1, double y2)
        {
            bool isHorizontal = (y1 == y2);
            return isHorizontal;
        }

        public static bool IsVertical(double x1, double x2)
        {
            bool isVertical = (x1 == x2);
            return isVertical;
        }
    }
}

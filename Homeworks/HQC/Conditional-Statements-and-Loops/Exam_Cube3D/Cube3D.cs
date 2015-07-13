namespace Exam_Cube3D
{
    using System;
    using MultidimensionalArrayExtensions;

    public static class Cube3D
    {
        public const string BordersSymbol = "*";
        public const string FrontSideSymbol = " ";
        public const string RightSideSymbol = "|";
        public const string BottomSideSymbol = "-";

        public static void Main()
        {
            var sideSize = int.Parse(Console.ReadLine());
            var symbols = new string[] { FrontSideSymbol, BordersSymbol, RightSideSymbol, BottomSideSymbol };

            var drawer = new CubeDrawer(sideSize, symbols);
            drawer.Draw();
        }
    }
}

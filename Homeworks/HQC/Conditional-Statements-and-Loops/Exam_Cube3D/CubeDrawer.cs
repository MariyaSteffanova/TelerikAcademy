namespace Exam_Cube3D
{
    using System;
    using Exam_Cube3D.MultidimensionalArrayExtensions;

    public class CubeDrawer
    {
        private int cubeLength2D;
        private int[,] cube;
        private string[] symbols;

        public CubeDrawer(int side, string[] symbols)
        {
            this.CubeSide = side;
            this.cubeLength2D = (2 * this.CubeSide) - 1;
            this.cube = new int[this.cubeLength2D, this.cubeLength2D];
            this.symbols = symbols;
        }

        public int CubeSide { get; set; }

        public void Draw()
        {
            this.FillBorders();
            this.FillFrontSide();
            this.FillAside();
            this.FillBottomSide();
            string[,] translatedCube = this.cube.Translate(this.symbols);
            translatedCube.Print();
        }

        public void FillBorders()
        {
            this.cube.FillDiagonal(1, this.CubeSide, this.cubeLength2D, 1);
            this.cube.FillDiagonal(this.CubeSide, 1, this.CubeSide, 1);
            this.cube.FillDiagonal(this.CubeSide, this.CubeSide, this.cubeLength2D, 1);

            this.cube.FillCol(this.cubeLength2D - 1, this.CubeSide, this.cubeLength2D, 1);
        }

        public void FillFrontSide()
        {
            this.cube.FillRow(0, 0, this.CubeSide, 1);
            this.cube.FillRow(this.CubeSide - 1, 0, this.CubeSide, 1);
            this.cube.FillCol(0, 1, this.CubeSide - 1, 1);
            this.cube.FillCol(this.CubeSide - 1, 1, this.CubeSide - 1, 1);
            this.cube.FillRow(this.cubeLength2D - 1, this.CubeSide - 1, this.cubeLength2D, 1);
        }

        public void FillAside()
        {
            for (int i = 1; i < this.CubeSide - 1; i++)
            {
                this.cube.FillDiagonal(i + 1, this.CubeSide, this.cubeLength2D - 1, 2);
            }
        }

        public void FillBottomSide()
        {
            for (int i = 0; i < this.CubeSide - 2; i++)
            {
                this.cube.FillRow(this.CubeSide + i, i + 2, this.CubeSide + i, 3);
            }
        }
    }
}

namespace JustBlueberry
{
    using System;
    using System.Text;
    using JustBlueberry.Interfaces;

    public class ConsoleRenderer : IRenderer
    {
        private int gameWorldRows;
        private int gameWorldCols;
        private char[,] gameWorld;

        public ConsoleRenderer(int rows, int cols)
        {
            this.GameWorldRows = rows;
            this.GameWorldCols = cols;
            this.GameWorld = new char[this.GameWorldRows, this.GameWorldCols];
        }

        public int GameWorldRows
        {
            get { return this.gameWorldRows; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidBlueberryException("Number of renderer rows must be a positive integer.");
                }
                this.gameWorldRows = value;
            }
        }

        public int GameWorldCols
        {
            get { return this.gameWorldCols; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidBlueberryException("Number of renderer cols must be a positive integer.");
                }
                this.gameWorldCols = value;
            }
        }

        public char[,] GameWorld
        {
            get { return this.gameWorld; }
            private set { this.gameWorld = value; }
        }

        public void Push(IRenderable objectToRender)
        {
            char objectToRenderShape = objectToRender.GetShape();
            Point objectToRenderPosition = objectToRender.GetPosition();
            if (objectToRenderPosition.Row < gameWorldRows && objectToRenderPosition.Col < gameWorldCols
                && objectToRenderPosition.Row >= 0 && objectToRenderPosition.Col >= 0)
            {
                this.gameWorld[objectToRenderPosition.Row, objectToRenderPosition.Col] = objectToRenderShape;
            }
        }

        public void Print()
        {
            Console.SetCursorPosition(0, 0);

            StringBuilder frameBuilder = new StringBuilder();
            for (int row = 0; row < this.gameWorldRows; row++)
            {
                for (int col = 0; col < this.gameWorldCols; col++)
                {
                    frameBuilder.Append(this.gameWorld[row, col]);
                }
                frameBuilder.AppendLine();
            }

            Console.WriteLine(frameBuilder.ToString());
        }

        public void Release()
        {
            for (int row = 0; row < this.gameWorldRows; row++)
            {
                for (int col = 0; col < this.gameWorldCols; col++)
                {
                    this.gameWorld[row, col] = ' ';
                }
            }
        }
    }
}

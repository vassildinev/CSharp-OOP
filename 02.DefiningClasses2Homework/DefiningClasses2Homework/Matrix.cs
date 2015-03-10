namespace DefiningClasses2Homework
{
    using System;
    using System.Collections;

    [Version("2.00")]
    class Matrix<T>
        : IEnumerable
        where T : struct
    {
        // fields
        private T[,] matrix;
        private int height;
        private int width;

        // constructor
        public Matrix(int height, int width)
        {
            this.Height = height;
            this.Width = width;

            this.matrix = new T[this.Height, this.Width];
        }

        // methods
        public void PrintMatrix()
        {
            for (int row = 0; row < this.Height; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    System.Console.Write(this[row, col] + "\t");
                }
                System.Console.WriteLine();
            }
        }

        // properties
        public int Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("Value must be greater than zero.");
                }
                this.height = value;
            }
        }
        public int Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("Value must be greater than zero.");
                }
                this.width = value;
            }
        }

        // operators
        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.Height != second.Height
                || first.Width != second.Width)
            {
                throw new System.ArithmeticException("Matrices should be of the same size for operator +.");
            }

            Matrix<T> result = new Matrix<T>(first.Height, first.Width);
            for (int row = 0; row < first.Height; row++)
            {
                for (int col = 0; col < first.Width; col++)
                {
                    result[row, col] = (dynamic)first[row, col] + second[row, col];
                }
            }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.Height != second.Height
                || first.Width != second.Width)
            {
                throw new System.ArithmeticException("Matrices should be of the same size for operator -.");
            }

            Matrix<T> result = new Matrix<T>(first.Height, first.Width);
            for (int row = 0; row < first.Height; row++)
            {
                for (int col = 0; col < first.Width; col++)
                {
                    result[row, col] = (dynamic)first[row, col] - second[row, col];
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first.Width!=second.Height)
            {
                throw new System.ArithmeticException("Matrix A should have a width equal to the height of Matrix B for the operator *.");
            }

            Matrix<T> result = new Matrix<T>(first.Height, second.Width);

            for (int row = 0; row < first.Height; row++)
            {
                for (int rep = 0; rep < second.Width; rep++)
                {
                    for (int col = 0; col < first.Width; col++)
                    {
                        result[row, rep] += (dynamic)first[row, col] * second[col, rep];
                    }
                }
            }
            return result;
        }

        public static bool operator true(Matrix<T> mtrx)
        {
            for (int row = 0; row < mtrx.Height; row++)
            {
                for (int col = 0; col < mtrx.Width; col++)
                {
                    if (mtrx[row, col]!=(dynamic)0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator false(Matrix<T> mtrx)
        {
            for (int row = 0; row < mtrx.Height; row++)
            {
                for (int col = 0; col < mtrx.Width; col++)
                {
                    if (mtrx[row, col] != (dynamic)0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // indexer
        public T this[int row, int col]
        {
            get
            {
                return this.matrix[row, col];
            }
            set
            {
                this.matrix[row, col] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int row = 0; row < this.Height; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    yield return this[row, col];
                }
            }
        }
    }
}

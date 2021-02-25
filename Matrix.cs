using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_cv3
{
    public class Matrix
    {
        private double[,] data;

        public Matrix(double[,] dataIn)
        {
            data = dataIn;
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            //GetLength(0) = y(height), GetLength(1) = x(width)
            //dimensions are different
            if (a.data.GetLength(0) != b.data.GetLength(0) || a.data.GetLength(1) != b.data.GetLength(1)) throw new Exception("Cannot add matrixes. The dimensions do not match!");
            double[,] result = new double[a.data.GetLength(0), a.data.GetLength(1)];
            for (uint y = 0; y < a.data.GetLength(0); y++)
            {
                for (uint x = 0; x < a.data.GetLength(1); x++)
                {
                    result[y, x] = a.data[y, x] + b.data[y, x];
                }
            }
            return new Matrix(result);
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            //dimensions are different
            if (a.data.GetLength(0) != b.data.GetLength(0) || a.data.GetLength(1) != b.data.GetLength(1)) throw new Exception("Cannot subtract matrixes. The dimensions do not match!");
            double[,] result = new double[a.data.GetLength(0), a.data.GetLength(1)];
            for (uint y = 0; y < a.data.GetLength(0); y++)
            {
                for (uint x = 0; x < a.data.GetLength(1); x++)
                {
                    result[y, x] = a.data[y, x] - b.data[y, x];
                }
            }
            return new Matrix(result);
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            //a width must = b height for multiplication to be possible
            if (a.data.GetLength(1) != b.data.GetLength(0)) throw new Exception("Cannot multiply matrixes. The dimensions are incorrect!");
            //result is height of a and width of b
            double[,] result = new double[a.data.GetLength(0), b.data.GetLength(1)];
            for (uint y = 0; y < result.GetLength(0); y++)
            {
                for (uint x = 0; x < result.GetLength(1); x++)
                {
                    result[y, x] = 0;
                    //need to add a width (b height) multiplications
                    for (uint mulIndex = 0; mulIndex < a.data.GetLength(1); mulIndex++)
                    {
                        result[y, x] += a.data[y, mulIndex] * b.data[mulIndex, x];
                    }
                }
            }
            return new Matrix(result);
        }
        public static bool operator ==(Matrix a, Matrix b)
        {
            //dimensions are different
            if (a.data.GetLength(0) != b.data.GetLength(0) || a.data.GetLength(1) != b.data.GetLength(1)) return false;
            for (uint y = 0; y < a.data.GetLength(0); y++)
            {
                for (uint x = 0; x < a.data.GetLength(1); x++)
                {
                    if (a.data[y, x] != b.data[y, x]) return false; //found a difference
                }
            }
            return true;    //didn't find any differences
        }
        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }
        public static Matrix operator -(Matrix a)
        {
            double[,] result = new double[a.data.GetLength(0), a.data.GetLength(1)];
            for (uint y = 0; y < result.GetLength(0); y++)
            {
                for (uint x = 0; x < result.GetLength(1); x++)
                {
                    result[y, x] = -a.data[y, x];
                }
            }
            return new Matrix(result);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");
            for (int y = 0; y < data.GetLength(0); y++)
            {
                for (int x = 0; x < data.GetLength(1); x++)
                {
                    result.Append(data[y, x]);
                    if (x + 1 != data.GetLength(1)) result.Append(",");
                }
                if (y + 1 != data.GetLength(0)) result.Append("\n");
            }
            return result.ToString();
        }
        public double Determinant()
        {
            if (data.GetLength(0) != data.GetLength(1)) throw new Exception("Cannot calculate determinant of a non-square matrix!");
            switch (data.GetLength(0))
            {
                case 0: //empty matrix
                    throw new Exception("Cannot calculate determinant of an empty matrix!");
                case 1: //1x1
                    return data[0, 0];
                case 2: //2x2
                    return data[0, 0] * data[1, 1] - data[1, 0] * data[0, 1];
                case 3: //3x3
                    return data[0, 0] * data[1, 1] * data[2, 2] + data[1, 0] * data[2, 1] * data[0, 2] + data[2, 0] * data[0, 1] * data[1, 2]
                           - data[2, 0] * data[1, 1] * data[0, 2] - data[1, 0] * data[0, 1] * data[2, 2] - data[0, 0] * data[2, 1] * data[1, 2];
                default:
                    throw new Exception("Determinant calculation of matrixes bigger than 3x3 is not supported!");
            }
        }
    }
}

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
            data = new double[dataIn.GetLength(0),dataIn.GetLength(1)];
            Array.Copy(dataIn, data, dataIn.Length);
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            //dimensions are different
            if (a.data.GetLength(0) != b.data.GetLength(0) || a.data.GetLength(1) != b.data.GetLength(1)) return new Matrix(new double[0, 0]);  //GetLength(0) = y(height), GetLength(1) = x(width)
            Matrix result = new Matrix(a.data);
            for(uint y = 0; y < a.data.GetLength(0); y++)
            {
                for (uint x = 0; x < a.data.GetLength(1); x++)
                {
                    result.data[y, x] += b.data[y, x];
                }
            }
            return result;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            //dimensions are different
            if (a.data.GetLength(0) != b.data.GetLength(0) || a.data.GetLength(1) != b.data.GetLength(1)) return new Matrix(new double[0, 0]);
            Matrix result = new Matrix(a.data);
            for (uint y = 0; y < a.data.GetLength(0); y++)
            {
                for (uint x = 0; x < a.data.GetLength(1); x++)
                {
                    result.data[y, x] -= b.data[y, x];
                }
            }
            return result;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            //a width == b height for multiplication to be possible
            if (a.data.GetLength(1) != b.data.GetLength(0)) return new Matrix(new double[0, 0]);
            //result is height of a and width of b
            Matrix result = new Matrix(new double[a.data.GetLength(0), b.data.GetLength(1)]);
            for (uint y = 0; y < result.data.GetLength(0); y++)
            {
                for (uint x = 0; x < result.data.GetLength(1); x++)
                {
                    result.data[y, x] = 0;
                    //need to add a width (b height) multiplications
                    for (uint mulIndex = 0; mulIndex < a.data.GetLength(1); mulIndex++)
                    {
                        result.data[y, x] += a.data[y, mulIndex] * b.data[mulIndex, x];
                    }
                }
            }
            return result;
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
            return true;
        }
        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }
        public static Matrix operator -(Matrix a)
        {
            Matrix result = new Matrix(a.data);
            for (uint y = 0; y < a.data.GetLength(0); y++)
            {
                for (uint x = 0; x < a.data.GetLength(1); x++)
                {
                    result.data[y, x] = -a.data[y, x];
                }
            }
            return result;
        }
        public override string ToString()
        {
            string result = "";
            for (int y = 0; y < data.GetLength(0); y++)
            {
                for (int x = 0; x < data.GetLength(1); x++)
                {
                    result += data[y, x];
                    if(x+1 != data.GetLength(1)) result += ",";
                }
                if(y+1 != data.GetLength(0)) result += "\n";
            }
            return result;
        }
    }
}

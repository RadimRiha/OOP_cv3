using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_cv3
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matA = new Matrix(new double[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
            Matrix matB = new Matrix(new double[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
            Console.WriteLine("Matrix A:\n{0}\n", matA.ToString());
            Console.WriteLine("Matrix B:\n{0}\n", matB.ToString());
            Console.WriteLine("A+B:\n{0}\n", (matA + matB).ToString());
            Console.WriteLine("A-B:\n{0}\n", (matA - matB).ToString());
            Console.WriteLine("A*B:\n{0}\n", (matA * matB).ToString());
            Console.WriteLine("A==B:\n{0}\n", matA == matB);
            Console.WriteLine("A!=B:\n{0}\n", matA != matB);
            Console.WriteLine("-A:\n{0}\n", -matA);
        }
    }
}

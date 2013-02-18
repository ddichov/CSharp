using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace _12.WorkWithPolynomials
{
    class WorkWithPolynomials
    {
        private static int InputPositiveInteger()
        {
            int n;
            do
            {
                Console.Write("Enter positive integer [1...10]: ");
            } while (int.TryParse(Console.ReadLine(), out n) == false || n < 1 || n > 10);
            return n;
        }

        private static int Menu()
        {
            int n;
            do
            {
                Console.WriteLine("MENU:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply ");
                Console.Write("Enter number : ");
            } while (int.TryParse(Console.ReadLine(), out n) == false || n < 1 || n > 3);
            return n;
        }

        private static decimal InputDecimal()
        {
            decimal n;
            do
            {
                //Console.Write("Enter decimal number: ");
            } while (decimal.TryParse(Console.ReadLine(), out n) == false);
            return n;
        }

        private static void InputCoeficients(ref decimal[] arr, int arayLenght)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            for (int i = arayLenght - 1; i >= 0; i--)
            {
                Console.WriteLine("Enter coefficient {0}: ", alphabet[arayLenght-1 - i]);
                arr[i] = InputDecimal();
            }
        }
        private static bool FindLongestArray(decimal[] arr1, decimal[] arr2)
        {
            if (arr1.Length >= arr2.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void SumArrysElements(ref decimal[] arrLongest, ref decimal[] arr2, ref decimal[] arrSum)
        {
            for (int i = 0; i < arrLongest.Length; i++)
            {
                if (i < arr2.Length)
                {
                    arrSum[i] = arrLongest[i] + arr2[i];
                }
                else
                {
                    arrSum[i] = arrLongest[i];
                }
            }
        }

        private static void MultiplyPolynomialsRepresentedAsArrys(ref decimal[] arrLongest, ref decimal[] arr2, ref decimal[] result)
        {
            for (int i = 0; i < arrLongest.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    result[i + j] = result[i + j] + arr2[j] * arrLongest[i];
                }
            }
        }

        private static void SubtrctionArrysElements(ref decimal[] arr1, ref decimal[] arr2, ref decimal[] result )
        {
            int maxLenght = Math.Max(arr1.Length, arr2.Length);
            for (int i = 0; i < maxLenght; i++)
            {
                if (i >= arr2.Length)
                {
                    result[i] = arr1[i] ;
                }
                else if ((i >= arr1.Length))
                {
                    result[i] = 0 - arr2[i];
                }
                else
                {
                    result[i] = arr1[i] - arr2[i];
                }
            }
        }

        private static void PrintPolynomial(decimal[] arr)
        {
            int length = arr.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                if (i > 0)
                {
                    Console.Write("( {0} * X^{1} ) + ", arr[i], i);
                }
                else
                {
                    Console.Write("( {0} ) ", arr[i], i);
                }
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            


            Console.WriteLine("This program works with two polynomials ( a * X^2 + b * X + c ) .");
            Console.WriteLine("Representing them as arrays of their coefficients .\n");
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Enter first polynom highest power of X :");
            decimal[] arr1 = new decimal[InputPositiveInteger()+1];

            Console.WriteLine("Enter first polynom coefficients :");
            InputCoeficients(ref arr1, arr1.Length);

            Console.WriteLine("Enter second polynom highest power of X :");
            decimal[] arr2 = new decimal[InputPositiveInteger()+1];

            Console.WriteLine("\nEnter second polynom coefficients :");
            InputCoeficients(ref arr2, arr2.Length);
            int longestArrayLength = Math.Max(arr1.Length, arr2.Length);
            int choice=Menu();
            Console.WriteLine();

            decimal[] arrResult; //
            PrintPolynomial(arr1);
            if (choice==1)
            {
                arrResult = new decimal[longestArrayLength];
                if (FindLongestArray(arr1, arr2))
                {
                    SumArrysElements(ref arr1, ref arr2, ref arrResult);
                    Console.WriteLine("+");
                }
                else
                {
                    SumArrysElements(ref arr2, ref arr1, ref arrResult);
                    Console.WriteLine("+");
                }
            }
            else if (choice==3)
            {
                arrResult = new decimal [arr1.Length+arr2.Length-1];
                if (FindLongestArray(arr1, arr2))
                {
                    MultiplyPolynomialsRepresentedAsArrys(ref arr1, ref arr2, ref arrResult);
                    Console.WriteLine("*");
                }
                else
                {
                    MultiplyPolynomialsRepresentedAsArrys(ref arr2, ref arr1, ref arrResult);
                    Console.WriteLine("*");
                }
            }
            else //choice==2
            {
                arrResult = new decimal[longestArrayLength];

                   SubtrctionArrysElements(ref arr1, ref arr2, ref arrResult);
                   Console.WriteLine("-");

               
            }

            
            PrintPolynomial(arr2);
            Console.WriteLine("\nResult :");
            PrintPolynomial(arrResult);
            Console.WriteLine();
        }
    }
}

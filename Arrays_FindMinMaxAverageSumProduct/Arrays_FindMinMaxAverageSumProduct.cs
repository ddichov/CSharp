using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Solve5tasks
{
    static bool isPositive = true;

    private static int Menu()
    {
        int n;
        do
        {
            Console.WriteLine("MENU:");
            Console.WriteLine("1. Find minimum");
            Console.WriteLine("2. Find maximum");
            Console.WriteLine("3. Calculate average");
            Console.WriteLine("4. Calculate sum");
            Console.WriteLine("5. Calculate product");
            Console.Write("Enter number : ");
        } while (int.TryParse(Console.ReadLine(), out n) == false || n < 1 || n > 5);
        return n;
    }

    private static int GetMinValue(ref int[] arr)
    {
        int minIndex = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[minIndex] > arr[i]) // arr[minIndex].CompareTo(arr[i])<0
            {
                minIndex = i;
            }
        }
        return arr[minIndex];
    }

    private static int GetMaxValue(ref int[] arr)
    {
        int maxIndex=0;
        for (int i = 1; i < arr.Length; i++) 
        {
            if (arr[maxIndex] < arr[i]) // arr[maxIndex].CompareTo(arr[i])<0
            {
                maxIndex = i;
            }
        }
        return arr[maxIndex];
    }

    private static decimal CalculateAverage(ref int[] arr)
    {
        long sum = CalculateSumOfIntegers(ref arr); //
        decimal average = sum / (decimal)arr.Length;
        return average;
    }

    private static long CalculateSumOfIntegers(ref int[] arr)
    {
        long sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }


    private static void MultiplyIntegrAndNumberAsList(int number, ref List<int> result)// can hold big integer
    {
        long temp = 0;
        for (int i = 0; i < result.Count; i++)
        {
            long multipl = 0;
            if (number < 0)
            {
                isPositive = !isPositive;
                number= number*(-1);
            }
            multipl = (result[i] * number + temp);
            result[i] = (int)(multipl % 10);
            temp = multipl / 10;
        }
        while (temp > 0)
        {
            result.Add((int)(temp % 10));
            temp = temp / 10;
        }
    }

    private static void PrintReversedList(List<int> arr)
    {
        for (int i = arr.Count - 1; i >= 0; i--)
        {
            Console.Write(arr[i]);
        }
        Console.WriteLine();
    }


    static void Main(string[] args)
    {
        int[] arr = { 10, 100, -1000, 10000, 100000, 1000000 }; //2, 3, 5, 1, 8, 3, 9, 2, 13, 4, 52, 28 };
        int choice = Menu();
        if (choice == 1)
        {
            Console.WriteLine(GetMinValue(ref arr));
        }
        else if (choice==2)
        {
            Console.WriteLine(GetMaxValue(ref arr));
        }
        else if (choice == 3)
        {
            Console.WriteLine(CalculateAverage(ref arr));
        }
        else if (choice == 4)
        {
            Console.WriteLine(CalculateSumOfIntegers (ref arr));
        }
        else // (choice == 5)
        {
            List<int> result = new List<int>();
            result.Add(1);
               
            for (int i = 0; i < arr.Length; i++)
            {
                MultiplyIntegrAndNumberAsList (arr[i], ref result);
            }
            if (isPositive==false)
            {
                Console.Write("-");
            }
            PrintReversedList(result);
        }

    }
}


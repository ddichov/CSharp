using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MergeSort
{
    static void Main(string[] args)
    {

        Console.WriteLine("This program reads an array of N integers from the console");
        Console.WriteLine("and sorts its elements in increasing order ussing MARGE SORT.\n");

        //input
        int arrayLength = InputArrayLength();
        int[] arr = new int[arrayLength];
        int[] tempArr = new int[arrayLength];
        ReadArrayElements(arrayLength, arr);
        Console.WriteLine();

        // solve
        for (int i = 1; i < arrayLength; i = 2*i)                   // start from 1
        {
            for (int j = 0; j < arrayLength - i; j= j + 2*i)        // 
            {
                int firstStartIndex = j;                            // first array start index
                int secondStartIndex = j + i;                       // second array start index
                int endIndex2 = Math.Min(j + 2*i, arrayLength );    // second array end (last index+1)
                int tempArrIndex = j;                               // temporary array start index
                while ((firstStartIndex < i+j) && secondStartIndex < endIndex2) // i+j=end of first array & start of second
                {
                    if (arr[firstStartIndex] < arr[secondStartIndex] )
                    {
                        tempArr[tempArrIndex] = arr[firstStartIndex];
                        firstStartIndex++;
                        tempArrIndex++;
                    }
                    else
                    {
                        tempArr[tempArrIndex] = arr[secondStartIndex];
                        secondStartIndex++;
                        tempArrIndex++;
                    }
                }
                while (firstStartIndex < i + j)
                {
                    tempArr[tempArrIndex] = arr[firstStartIndex];
                    firstStartIndex++;
                    tempArrIndex++;
                }
                while (secondStartIndex < endIndex2)
                {
                    tempArr[tempArrIndex] = arr[secondStartIndex];
                    secondStartIndex++;
                    tempArrIndex++;
                }
                for (int x = endIndex2 - 1; x >= j; x--) //
                {
                    arr[x] = tempArr[x];
                }
            }
        }

        Console.WriteLine( );
        PrintSortedArray(arrayLength, arr);
        Console.WriteLine();

    }


    private static void PrintSortedArray(int arrayLength, int[] arr)
    {
        Console.WriteLine("Sorted array :");
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write(" {0}", arr[i]);
        }
    }

    private static void ReadArrayElements(int arrayLength, int[] arr)
    {
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write("Enter Array element {0}: ", i);
            arr[i] = ReadInteger();
        }
    }

    private static int ReadInteger()
    {
        int number;
        while (int.TryParse(Console.ReadLine(), out number) == false)
        {
            Console.WriteLine("Error! Input integer:");
        }
        return number;
    }

    private static int InputArrayLength()
    {
        int arrayLength = 0;
        do
        {
            Console.WriteLine("Enter Array length:");
            arrayLength = ReadInteger();
        } while (arrayLength <= 0);
        return arrayLength;
    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class SequenceOfMaxSum
{
    static void Main(string[] args)
    {
        

        int currentSum = 0;
        int currentSeqLength = 0;
        int currentStartIndex = 0;

        int bestSum = 0;
        int bestSeqLength = 0;
        int bestStartIndex = 0;

        Console.WriteLine("This program reads an array of integers from the console");
        Console.WriteLine("and finds the sequence of maximal sum in the array.");
        Console.WriteLine("With single scan through the elements of the array!");
            
        //input
        int arrayLength = InputArrayLength();
        int[] arr = new int[arrayLength];
        ReadArrayElements(arrayLength, arr);
        Console.WriteLine();

        // solve
        for (int i = 0; i < arrayLength; i++)
        {
            currentSum += arr[i];
            if (currentSum>bestSum)
            {
                bestSum = currentSum;
                currentSeqLength++;
                bestSeqLength = currentSeqLength;
                bestStartIndex = currentStartIndex;
            }
            else if (currentSum<bestSum && currentSum>0)
            {
                currentSeqLength++;
            }
            else if (currentSum<0)
	        {
                currentSum=0;
                currentSeqLength = 0;
                if (i<arrayLength-1)
                {
                    currentStartIndex = i + 1;
                }
            }
        }

        //printing result
        Console.WriteLine("Best sum is: {0}", bestSum);
        PrintBestSequence(bestSeqLength, bestStartIndex, arr);

    }


    private static void PrintBestSequence(int bestSeqLength, int bestStartIndex, int[] arr)
    {
        Console.WriteLine("Best sequence :");
        for (int i = bestStartIndex; i < bestStartIndex + bestSeqLength; i++)
        {
            Console.WriteLine(arr[i]);
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


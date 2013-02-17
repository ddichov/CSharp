using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class SegmentDigits
{
    static StringBuilder sb;

    static void Main()
    {

        int n = int.Parse(Console.ReadLine()); // number of displays
        byte[,] digits = new byte[n, 7];
        List<string> result = new List<string>();

        sb = new StringBuilder(n);
        int startIndex = 0;
        int endIndex = 0;

        // read the input
        for (int row = 0; row < n; row++)
        {
            string temp = Console.ReadLine().Trim();
            for (int col = 0; col < 7; col++)
            {
                digits[row, col] = byte.Parse(temp[col].ToString());
            }
        }

        // Check For Posible Digits visualisatoins
        for (int displayNumber = n - 1; displayNumber >= 0; displayNumber--)
        {
            if (displayNumber == n - 1)
            {
                FirstChecksForPosibleDigits(digits, result, displayNumber);
                endIndex = result.Count;
            }
            else
            {
                NextCheckForPosibleDigits( digits, result, startIndex, endIndex, displayNumber);
                startIndex = endIndex;
                endIndex = result.Count;
            }
        }
        Console.WriteLine(endIndex - startIndex);
        PrintResult(result, startIndex, endIndex);
    }

    private static void NextCheckForPosibleDigits( byte[,] digits, List<string> result, int startIndex, int endIndex, int displayNumber)
    {
        if (digits[displayNumber, 6] == 0)
        {
            AddDigit(result, startIndex, endIndex, "0");
        }
        if (digits[displayNumber, 0] == 0 && digits[displayNumber, 3] == 0 && digits[displayNumber, 4] == 0 && digits[displayNumber, 5] == 0 && digits[displayNumber, 6] == 0)
        {
            AddDigit(result, startIndex, endIndex, "1");
        }
        if (digits[displayNumber, 2] == 0 && digits[displayNumber, 5] == 0)
        {
            AddDigit(result, startIndex, endIndex, "2");
        }
        if (digits[displayNumber, 4] == 0 && digits[displayNumber, 5] == 0)
        {
            AddDigit(result, startIndex, endIndex, "3");
        }
        if (digits[displayNumber, 0] == 0 && digits[displayNumber, 3] == 0 && digits[displayNumber, 4] == 0)
        {
            AddDigit(result, startIndex, endIndex, "4");
        }
        if (digits[displayNumber, 1] == 0 && digits[displayNumber, 4] == 0)
        {
            AddDigit(result, startIndex, endIndex, "5");
        }
        if (digits[displayNumber, 1] == 0)
        {
            AddDigit(result, startIndex, endIndex, "6");
        }
        if (digits[displayNumber, 3] == 0 && digits[displayNumber, 4] == 0 && digits[displayNumber, 5] == 0 && digits[displayNumber, 6] == 0)
        {
            AddDigit(result, startIndex, endIndex, "7");
        }
        AddDigit(result, startIndex, endIndex, "8");
        if (digits[displayNumber, 4] == 0)
        {
            AddDigit(result, startIndex, endIndex, "9");
        }
    }

    private static void FirstChecksForPosibleDigits(byte[,] digits, List<string> result, int displayNumber)
    {
        if (digits[displayNumber, 6] == 0)
        {
            result.Add("0");
        }
        if (digits[displayNumber, 0] == 0 && digits[displayNumber, 3] == 0 && digits[displayNumber, 4] == 0 && digits[displayNumber, 5] == 0 && digits[displayNumber, 6] == 0)
        {
            result.Add("1");
        }
        if (digits[displayNumber, 2] == 0 && digits[displayNumber, 5] == 0)
        {
            result.Add("2");
        }
        if (digits[displayNumber, 4] == 0 && digits[displayNumber, 5] == 0)
        {
            result.Add("3");
        }
        if (digits[displayNumber, 0] == 0 && digits[displayNumber, 3] == 0 && digits[displayNumber, 4] == 0)
        {
            result.Add("4");
        }
        if (digits[displayNumber, 1] == 0 && digits[displayNumber, 4] == 0)
        {
            result.Add("5");
        }
        if (digits[displayNumber, 1] == 0)
        {
            result.Add("6");
        }
        if (digits[displayNumber, 3] == 0 && digits[displayNumber, 4] == 0 && digits[displayNumber, 5] == 0 && digits[displayNumber, 6] == 0)
        {
            result.Add("7");
        }
        result.Add("8");
        if (digits[displayNumber, 4] == 0)
        {
            result.Add("9");
        }
    }

    private static void PrintResult(List<string> result, int startIndex, int endIndex)
    {
        for (int i = startIndex; i < endIndex; i++)
        {
            Console.WriteLine(result[i]);
        }
    }

    private static void AddDigit(List<string> result, int startIndex, int endIndex, string digit)
    {
        for (int i = startIndex; i < endIndex; i++)
        {
            sb.Clear();
            sb.Append(digit);
            sb.Append(result[i]);
            result.Add(sb.ToString());
        }
    }
}

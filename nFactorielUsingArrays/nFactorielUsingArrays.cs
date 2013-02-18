using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class nFactorielUsingArrays
{
	static List<int> result= new List<int>();

	private static int InputPositiveInteger()
	{
		int n;
		do
		{
			Console.Write("Enter number N: ");
		} while (int.TryParse(Console.ReadLine(), out n) == false || n < 1 || n > 100);
		return n;
	}


	private static void MultiplyIntegrAndNumberAsArry(int n, ref List<int> result)
	{
		long temp = 0;
		for (int i = 0; i < result.Count; i++)
		{
			long multipl = 0;
			multipl = (result[i] * n + temp);
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

	static void Main()
	{
		Console.WriteLine("This program calculates N! for each N in the range [1..100].");
		Console.WriteLine("Using method that multiplies a number represented as array of digits by given integer number.\n");

		result.Add(1);
		int n = InputPositiveInteger();

		for (int i = 1; i <= n; i++)
		{
			MultiplyIntegrAndNumberAsArry(i, ref result);
		}
		PrintReversedList(result);

	}
}


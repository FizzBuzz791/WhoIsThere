using System;
using System.Linq;
using System.Text;

namespace WhoIsThere.Services
{
	public class WhoIsThereService
	{
		public long CalculateFibonacci(long n)
		{
			const int MAX = 92;
			if (n > MAX || n < -MAX)
				throw new ArgumentException($"Value must be in the range {-MAX} <= n <= {MAX} to prevent long overflow.", nameof(n));

			// phi
			double phi = (1.0 + Math.Sqrt(5.0)) / 2.0;

			// Binet's Formula (approximation - loses accuracy when n > 70)
			long result = Convert.ToInt64(Math.Pow(phi, Math.Abs(n)) / Math.Sqrt(5));
			
			if (n < 0 && n % 2 == 0)
			{
				// Account for negafibonacci numbers?
				result = -result;
			}

			return result;
		}

		public string ReverseWords(string sentence)
		{
			if (sentence == null)
			{
				sentence = string.Empty;
			}
				
			string[] words = sentence.Split(" ");
			StringBuilder newSentence = new StringBuilder();

			string[] reversedWords = words.Select(word => new string(word.ToCharArray().Reverse().ToArray())).ToArray();

			return newSentence.AppendJoin(" ", reversedWords).ToString();
		}

		public string DetermineTriangleType(int a, int b, int c)
		{
			bool isTriangle = true;

			// First, determine if the given lengths can be a triangle of any sort.
			// 1. All lengths must be greater than 0.
			if (a <= 0 || b <= 0 || c <= 0)
			{
				isTriangle = false;
			}
			// 2. Ensure the sum of any two lengths is greater than the third (not degenerate).
			else if ((long)a + b <= c)
			{
				isTriangle = false;
			}
			else if ((long)a + c <= b)
			{
				isTriangle = false;
			}
			else if ((long)b + c <= a)
			{
				isTriangle = false;
			}

			string type = "Error";
			
			if (isTriangle)
			{
				if (a == b && a == c)
				{
					type = "Equilateral";
				} 
				else if (a == b || a == c || b == c)
				{
					type = "Isosceles";
				}
				else if (a != b && a != c && b != c)
				{
					type = "Scalene";
				}
			}

			return type;
		}
	}
}
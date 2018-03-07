using System;
using NUnit.Framework;
using WhoIsThere.Services;

namespace WhoIsThere.Tests
{
	[TestFixture]
	public class WhoIsThereServiceTests
	{
		[TestCase(-4, -3)]
		[TestCase(-5, 5)]
		[TestCase(-6, -8)]
		[TestCase(0, 0)]
		[TestCase(1, 1)]
		[TestCase(2, 1)]
		[TestCase(3, 2)]
		[TestCase(4, 3)]
		[TestCase(31, 1346269)]
		[TestCase(70, 190392490709135)]
		public void CalculateFibonacci_ReturnsCorrectResult(int fibNum, long expectedResult)
		{
			// Arrange
			WhoIsThereService sut = new WhoIsThereService();

			// Act
			long result = sut.CalculateFibonacci(fibNum);

			// Assert
			Assert.That(result, Is.EqualTo(expectedResult));
		}

		[Test]
		public void CalculateFibonacci_ThrowsBeforeArithmeticOverflow()
		{
			// Arrange
			WhoIsThereService sut = new WhoIsThereService();

			// Act
			
			// Assert
			Assert.Throws(typeof(ArgumentException), () => sut.CalculateFibonacci(93));
		}

		[TestCase(null, "")]
		[TestCase(" ", " ")]
		[TestCase("Trent", "tnerT")]
		[TestCase("Trent Jones", "tnerT senoJ")]
		[TestCase("trailing space ", "gniliart ecaps ")]
		[TestCase("Bang!", "!gnaB")]
		[TestCase("", "")]
		[TestCase("double  space", "elbuod  ecaps")]
		[TestCase(" leading space", " gnidael ecaps")]
		[TestCase(" s p a c e ", " s p a c e ")]
		[TestCase("P!u@n#c$t%u^a&t*i(o)n", "n)o(i*t&a^u%t$c#n@u!P")]
		public void ReverseWords_ReturnsCorrectResult(string sentence, string expectedResult)
		{
			// Arrange
			WhoIsThereService sut = new WhoIsThereService();

			// Act
			string result = sut.ReverseWords(sentence);

			// Assert
			Assert.That(result, Is.EqualTo(expectedResult));
		}

		[TestCase(0, 0, 0, "Error")]
		[TestCase(1, 1, 2, "Error")]
		[TestCase(-1, 0, 1, "Error")]
		[TestCase(-1, -1, -1, "Error")]
		[TestCase(-1, 1, 1, "Error")]
		[TestCase(1, -1, 1, "Error")]
		[TestCase(1, 1, -1, "Error")]
		[TestCase(3, 3, 5000, "Error")]
		[TestCase(1, 1, Int32.MaxValue, "Error")]
		[TestCase(Int32.MinValue, Int32.MinValue, Int32.MinValue, "Error")]
		[TestCase(1, 1, 1, "Equilateral")]
		[TestCase(Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, "Equilateral")]
		[TestCase(3, 3, 5, "Isosceles")]
		[TestCase(10, 10, 5, "Isosceles")]
		[TestCase(15, 1, 15, "Isosceles")]
		[TestCase(3, 4, 5, "Scalene")]
		[TestCase(5, 3, 4, "Scalene")]
		[TestCase(4, 5, 3, "Scalene")]
		public void TriangleType_ReturnsCorrectResult(int a, int b, int c, string expectedResult)
		{
			// Arrange
			WhoIsThereService sut = new WhoIsThereService();

			// Act
			string result = sut.DetermineTriangleType(a, b, c);

			// Assert
			Assert.That(result, Is.EqualTo(expectedResult));
		}
	}
}
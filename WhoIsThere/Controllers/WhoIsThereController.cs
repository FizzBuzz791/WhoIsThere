using Microsoft.AspNetCore.Mvc;
using WhoIsThere.Services;

namespace WhoIsThere.Controllers
{
	[Route("api/[controller]")]
	public class WhoIsThereController : Controller
	{
		private WhoIsThereService WhoIsThereService { get; }

		public WhoIsThereController()
		{
			WhoIsThereService = new WhoIsThereService();
		}

		[HttpGet(nameof(Token))]
		public string Token()
		{
			return "eb4f4c29-d479-4a0b-a92f-82a1800e08b3";
		}

		[HttpGet(nameof(Fibonacci))]
		public long Fibonacci(long n)
		{
			return WhoIsThereService.CalculateFibonacci(n);
		}

		[HttpGet(nameof(ReverseWords))]
		public string ReverseWords(string sentence)
		{
			return WhoIsThereService.ReverseWords(sentence);
		}

		[HttpGet(nameof(TriangleType))]
		public string TriangleType(int a, int b, int c)
		{
			return WhoIsThereService.DetermineTriangleType(a, b, c);
		}
	}
}
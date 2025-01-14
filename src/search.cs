using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fuzzierinter.Searcher
{
	public class Searcher
	{
		public string url = "https://api.duckduckgo.com/";
		public Dictionary<string, string> parameters = new();
		public HttpClient client = new();
		public string query;
		public string responseContent = string.Empty;

		public Searcher(string q)
		{
			query = q;
			Setup();
		}

		private void Setup()
		{
			parameters.Add("q", query);
			parameters.Add("format", "json");
		}

		public async Task<string> Search()
		{
			try
			{
				var response = await client.GetAsync($"{url}?q={query}&format=json");
				response.EnsureSuccessStatusCode(); // Throws an exception if the status code is not successful
				responseContent = await response.Content.ReadAsStringAsync();
				Console.WriteLine(responseContent);
				return responseContent;
			}
			catch (HttpRequestException e)
			{
				Console.WriteLine($"Request error: {e.Message}");
				return string.Empty;
			}
			catch (Exception e)
			{
				Console.WriteLine($"Unexpected error: {e.Message}");
				return string.Empty;
			}
		}
	}
}

// Usage
public class Program
{
	public static async Task Main(string[] args)
	{
		var searcher = new fuzzierinter.Searcher.Searcher("example query");
		await searcher.Search();
	}
}

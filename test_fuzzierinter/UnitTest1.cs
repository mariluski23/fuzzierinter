using NUnit.Framework;
using fuzzierinter.Lexer;
using fuzzierinter;


namespace test_fuzzierinter
{
	[TestFixture] // Marks this class as a test container
	public class Tests
	{
		private Lexer lexer;

		[SetUp]
		public void Setup()
		{
			// Initialize before each test
			lexer = new Lexer();
		}

		[Test]
		public void TestTokenizeAndPrint()
		{
			string input = "SORT linked IN \"wikipedia.org\" \"Fuzzy searching\"";

			lexer.Tokenize(input);
		}
	}
}

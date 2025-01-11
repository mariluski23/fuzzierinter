using System.Text;

namespace fuzzierinter.Lexer
{
	public class Lexer
	{
		/// <summary>
		/// A list of all tokens the lexer can recognize.
		/// </summary>
		public enum Tokens
		{
			EOF,
			SEARCH,
			OR,
			AND,
			NOT,
			FROM,
			IN,
			EXACT,
			SORT,
			ORDER,
		}

		public enum SortValues
		{
			LINKED,
			DATE,
		}

		public enum OrderValues
		{
			ASC,
			DESC,
		}

		public enum FromValues
		{
			CONTENT,
			TITLE,
			DESCRIPTION
		}

		/// <summary>
		/// A class that represents a single token.
		/// </summary>
		public class Token
		{
			public Tokens Type;
			public string Value;

			public Token(Tokens type, string value)
			{
				Type = type;
				Value = value;
			}
		}

		// List of recognized tokens, all in lowercase
		private static readonly Dictionary<string, Tokens> Keywords = new Dictionary<string, Tokens>
		{
			{ "search", Tokens.SEARCH },
			{ "or", Tokens.OR },
			{ "and", Tokens.AND },
			{ "not", Tokens.NOT },
			{ "from", Tokens.FROM },
			{ "in", Tokens.IN },
			{ "exact", Tokens.EXACT },
			{ "sort", Tokens.SORT },
			{ "order", Tokens.ORDER }
		};

		// A list to hold the parsed tokens
		public List<Token> ParsedTokens = new();

		// Method to tokenize the input string
		public Token[] Tokenize(string input)
		{
			int index = 0;
			while (index < input.Length)
			{
				char currentChar = input[index];

				// Skip whitespace
				if (char.IsWhiteSpace(currentChar))
				{
					index++;
					continue;
				}

				// Handle keywords
				if (char.IsLetter(currentChar))
				{
					StringBuilder keyword = new StringBuilder();
					while (index < input.Length && char.IsLetter(input[index]))
					{
						keyword.Append(char.ToLower(input[index]));  // Convert to lowercase
						index++;
					}

					// Check if the keyword is recognized
					string keywordStr = keyword.ToString();
					if (Keywords.ContainsKey(keywordStr))
					{
						ParsedTokens.Add(new Token(Keywords[keywordStr], keywordStr));
					}
					else
					{
						// Handle unrecognized keywords (you can create an error token here if needed)
						ParsedTokens.Add(new Token(Tokens.EOF, keywordStr));
					}
				}
				// Handle other operators or punctuation (like ":", "(", etc.)
				else if (currentChar == ':')
				{
					ParsedTokens.Add(new Token(Tokens.EOF, ":"));
					index++;
				}
				else
				{
					// Skip invalid characters or handle them as unknown
					index++;
				}

				return ParsedTokens.ToArray();
			}

			// Add an EOF token to signify the end of input
			ParsedTokens.Add(new Token(Tokens.EOF, ""));
		}

		// Method to print out tokens for testing purposes
		public void PrintTokens()
		{
			foreach (var token in ParsedTokens)
			{
				Console.WriteLine($"Type: {token.Type}, Value: {token.Value}");
			}
		}
	}
}

using System.Text;
using System.Text.RegularExpressions;

namespace fuzzierinter
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
			STRING,
			URL,
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
		private static readonly Dictionary<string, Tokens> Keywords = new()
						{
							{ "search", Tokens.SEARCH },
							{ "or", Tokens.OR },
							{ "and", Tokens.AND },
							{ "not", Tokens.NOT },
							{ "from", Tokens.FROM },
							{ "in", Tokens.IN },
							{ "exact", Tokens.EXACT },
							{ "sort", Tokens.SORT },
							{ "order", Tokens.ORDER },
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

				// Handle URLs
				if (input[index..].StartsWith("http://") || input.Substring(index).StartsWith("https://"))
				{
					StringBuilder url = new StringBuilder();
					while (index < input.Length && !char.IsWhiteSpace(input[index]))
					{
						url.Append(input[index]);
						index++;
					}
					ParsedTokens.Add(new Token(Tokens.URL, url.ToString()));
				}
				// Handle keywords
				else if (char.IsLetter(currentChar))
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
				// Handle strings
				else if (currentChar == '"')
				{
					StringBuilder str = new StringBuilder();
					index++; // Skip the opening quote
					while (index < input.Length && input[index] != '"')
					{
						str.Append(input[index]);
						index++;
					}
					index++; // Skip the closing quote
					ParsedTokens.Add(new Token(Tokens.STRING, str.ToString()));

					// Add a SEARCH token before the STRING token
					ParsedTokens.Insert(ParsedTokens.Count - 1, new Token(Tokens.SEARCH, "search"));
				}
				else
				{
					// Skip invalid characters or handle them as unknown
					index++;
				}
			}

			// Add an EOF token to signify the end of input
			ParsedTokens.Add(new Token(Tokens.EOF, ""));

			return ParsedTokens.ToArray();
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

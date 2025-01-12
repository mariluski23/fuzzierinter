using System;
using System.Collections.Generic;

namespace fuzzierinter
{
	/// <summary>
	/// A class that represents a parser for the query language.
	/// </summary>
	public class Parser
	{
		private Lexer.Lexer lexer = new();
		private List<Lexer.Lexer.Token> tokens;
		private int currentToken = 0;

		public Parser(string input)
		{
			tokens = new List<Lexer.Lexer.Token>(lexer.Tokenize(input));
		}

		private Lexer.Lexer.Token CurrentToken => tokens[currentToken];

		private void Advance()
		{
			if (currentToken < tokens.Count - 1)
			{
				currentToken++;
			}
		}

		private bool Match(Lexer.Lexer.Tokens tokenType)
		{
			if (CurrentToken.Type == tokenType)
			{
				Advance();
				return true;
			}
			return false;
		}

		public string InsideQuotes()
		{
			if (Match(Lexer.Lexer.Tokens.STRING))
			{
				// Get the thing inside the quotes
				string value = CurrentToken.Value.Substring(1, CurrentToken.Value.Length - 2);
				Advance(); // Advance after extracting the value
				return value;
			}
			return "";
		}

		/// <summary>
		/// Pairs a token with its next token if it is a string.
		/// </summary>
		/// <returns>
		/// An array with the keyword and the string.
		/// </returns>
		/// <param name="idx">
		/// The index (starting from 0) of the token to pair.
		/// </param>
		public string[] Pair(int idx)
		{
			// Get the keyword
			string keyword = tokens[idx].Value;
			// Get the string
			string value = tokens[idx + 1].Value;
			return new string[] { keyword, value };
		}

		/// <summary>
		/// Returns the parsed tokens.
		/// </summary>
		/// <returns>
		/// An array of arrays with the keyword and the string paired.
		/// </returns>
		public string[][] Parse()
		{
			// A list where the paired tokens will be stored
			List<string[]> pairedTokens = new();

			// Loop through the tokens
			for (int i = 0; i < tokens.Count; i++)
			{
				// Pair the token with the next token if it is a string
				if (i < tokens.Count - 1 && tokens[i + 1].Type == Lexer.Lexer.Tokens.STRING)
				{
					pairedTokens.Add(Pair(i));
					i++; // Skip the next token as it is already paired
				}
			}

			return pairedTokens.ToArray();
		}
	}
}

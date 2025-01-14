using System;

namespace fuzzierinter.src.algorithms
{
	class BitapAlgorithm
	{
		/// <summary>
		/// A function that creates a bitmask for a pattern and text
		/// </summary>
		/// <param name="pattern">The pattern to create a bitmask for</param>
		/// <param name="text">The text to create a bitmask for</param>
		/// <returns>A bitmask for the pattern and text</returns>
		public static int[] MakeBitmask(string pattern, string text)
		{
			int patternLength = pattern.Length;
			int textLength = text.Length;

			// Create an array of bitmasks for each character in the pattern
			int[] bitmasks = new int[patternLength];

			// Initialize bitmasks for each character in the pattern
			for (int i = 0; i < patternLength; i++)
			{
				char currentChar = pattern[i];
				int bitmask = 0;

				// Create the bitmask for the current character
				for (int j = 0; j < textLength; j++)
				{
					if (text[j] == currentChar)
					{
						bitmask |= 1 << textLength - 1 - j; // Set the bit at the corresponding position
					}
				}

				bitmasks[i] = bitmask; // Store the bitmask for the current character
			}

			return bitmasks; // Return the array of bitmasks
		}

		/// <summary>
		/// A function that performs the Bitap search algorithm
		/// </summary>
		/// <param name="pattern">The pattern to search for</param>
		/// <param name="text">The text to search in</param>
		/// <param name="maxErrors">The maximum number of allowed mismatches</param>
		/// <returns>True if the pattern is found, otherwise false</returns>
		public static bool BitapSearch(string pattern, string text, int maxErrors)
		{
			int[] bitmasks = MakeBitmask(pattern, text);
			int patternLength = pattern.Length;
			int textLength = text.Length;

			// Initialize the state variable
			int[] S = new int[maxErrors + 1];
			S[0] = 0; // No errors

			// Iterate through each character in the text
			for (int i = 0; i < textLength; i++)
			{
				// Update the state for the current character
				int oldS0 = S[0];
				S[0] = S[0] << 1 | bitmasks[0]; // Shift left and add the first bitmask

				// Check for matches with allowed errors
				for (int j = 1; j <= maxErrors; j++)
				{
					// Store the previous state
					int temp = S[j];
					S[j] = oldS0 & bitmasks[j] | S[j] << 1; // Update state with the current character's bitmask
					oldS0 = temp; // Update oldS0 for the next iteration
				}

				// Check if the last bits indicate a match with allowed errors
				for (int j = 0; j <= maxErrors; j++)
				{
					if ((S[j] & 1 << patternLength - 1) != 0)
					{
						return true; // Pattern found with allowed errors
					}
				}
			}

			return false; // Pattern not found
		}
	}
}

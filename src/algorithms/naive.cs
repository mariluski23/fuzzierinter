namespace fuzzierinter.src.algorithms
{
	/// <summary>
	/// The NaiveAlgorithm class is a class with functions with implementations of the Naive Algorithm
	/// 
	/// The Naive Algorithm is a simple algorithm that searches for a pattern
	/// in a text.
	/// 
	/// Time complexity: O(n * m)
	/// Space complexity: O(1)
	/// </summary>
	class NaiveAlgorithm
	{
		public static int[] Search(string pat, string txt)
		{
			List<int> timesFound = new();
			int M = pat.Length;
			int N = txt.Length;

			// A loop to slide pat[] one by one
			for (int i = 0; i <= N - M; i++)
			{
				int j;

				// For current index i, check for pattern match
				for (j = 0; j < M; j++)
				{
					if (txt[i + j] != pat[j])
					{
						break;
					}
				}

				// If pattern matches at index i
				if (j == M)
				{
					// Add the value of i to the list
					timesFound.Add(i);
				}
			}

			// Return the list
			return timesFound.ToArray();
		}
	}
}

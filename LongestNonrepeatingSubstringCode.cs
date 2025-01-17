class MyLongestSubstringWithoutRepeatingCharactersSolution
{
	static void Main()
	{
		int m = 0; // Letter of a substring at left boundary.
		int n = 0; // Letter of a substring compares with index "m".
		int b = 0; // Initial index of b.
		int c = 0; // Initial index of c.
		int y = 0; // Index info of first repeating letter.
		string preWord = " "; // Initial previous substring. 
		int oldRepeatCount = 0; // Counter for previous step letter repetition.
		int newRepeatCount = 0; // Counter for current step letter repetition.
		var longestSubCharArray = ""; // Initial longest substring array without repeating after ordered.  
		string longestSubString = ""; // Initial longest substring without repeating after ordered.
		int longestLength = 0; // Initial longest substring length.
		List<char> curChar = new List<char>(); // Initial character list of curWord.
		string s = Console.ReadLine(); // String input.

		Stopwatch sw = Stopwatch.StartNew();

		int len = s.Length; // Length of the string "s".
		string input = new string(s);
		string subStrings = "";
		List<string> noRepeat = new List<string>(); // Non-repeating substring list.

		// In below statement, in case there is any single white space is written to console, code will count it as a character.

		if (s == " ")
		{
			char replacementChar = ' '; // The character to replace white space with
			string modifiedString = s.Replace(' ', replacementChar);
			Console.WriteLine(modifiedString.Length);
		}
		else
		{
			while (m < len) //There will be 2 nested for loops to contain every possible substring with every possible length combination.
			{
				for (n = m; n < len; n++) //Inner loop starts with the index of outer loop and increases from there.
				{
					subStrings = input.Substring(m, n - m + 1);
					int l = subStrings.Length; // Length of the current substring.
					string curWord = subStrings; // Current substring.
					curChar = curWord.ToList(); // Current character list of the current substring.

					// There should be a for loop for deciding whether there are repeating letters in curWord or not by checking all letters effectively.
					// Thus this goal is achieved by recording the previous non-repeating substrings and comparing only upcoming letter
					// with the previous lettes in curWord. Thus, n-m gives a c value that represents the last letter in curWord which is compared in a loop
					// of all letters in the curWord as can be seen below.
					
					c = n - m;  
					for (b = 0; b < l; b++) // The reference letter in the letter group to be compared with itself and the others.
					{
						if (curChar[b] == curChar[c]) // Questions whether the reference letter (b), is equal to the other letters (c) or not.
						{
							newRepeatCount++; // It increases if any of letters in a loop are same until counter reaches to "2", meaning that it repeats 2 times, one is repetitin with itself and other is with letter from another index.
							if (newRepeatCount == 1 && noRepeat.Contains(preWord) == true) // This condition helps us to save the repeating letter's index value by comparing previous repeat count and current repeat count.
							{
								if (oldRepeatCount < newRepeatCount)
								{
									y = c; // if previous and current repeat counts are different, index "y" is saved as the current index "c".  
								}
								else
								{
									y = 1; // if they are equal, y is considered as 1.
								}
							}
							else if (newRepeatCount == 2)
							{
								break;
							}
						}
						if (l - 1 == b && newRepeatCount == 1) // if the current letter is the last letter of the curWord and repeat count is 1 meaning letter only repeats with itself, curWord deserves to be added to noRepeat list.
						{
							noRepeat.Add(curWord);
						}
					}
					longestSubCharArray = noRepeat.OrderByDescending(x => x.Length).First(); // Ordering of list of non repeating substrings with respect to their length. 
					longestSubString = new string(longestSubCharArray);
					noRepeat.Clear(); // Clears previous added substrings to relieve memory, only leaves the longest substring. 
					noRepeat.Add(longestSubString);
					preWord = curWord; // Assigns current substring to previous substring.

					// In following if statements, in case code enters any of them, "oldRepeatCount = newRepeatCount" assignment must be defined.

					if (newRepeatCount == 2 )
					{
						oldRepeatCount = newRepeatCount;
						newRepeatCount = 0;
						m = m + y; // In this condition, if current repeat count equals to 2, m is increased by amount of y index to start to new substring iteration just after the first repeating letter since it is meaningless to continue with same m while repeat count is already 2. 
						break; // Breaks the for loop and goes to while loop with increased m.
					}
					else if (len-1 == n && newRepeatCount == 1) // If last index of the string is reached and repeat count is 1, m is increased by 1, and since "n" is last index, no need for break function it will automatically ends the loop. 
					{
						oldRepeatCount = newRepeatCount;
						newRepeatCount = 0;
						m++;
					}
					else
					{
						oldRepeatCount = newRepeatCount; // Else the for loop with "n" will just continue with same "m" until the loop ends.  
						newRepeatCount = 0;
					}
				}
			}
				longestLength = longestSubString.Length;
				Console.WriteLine(longestSubString);
				Console.WriteLine(longestLength); // Returns the length of the longest non-repeating substring.
		}
		sw.Stop();
		Console.WriteLine("Time taken: {0}ms", sw.Elapsed.TotalMilliseconds);
	}
}

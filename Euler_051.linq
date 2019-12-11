<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	int[][] fiveDigitPattern = get5digitPatterns();
	int[][] sixDigitPattern = get6digitPatterns();
	int result = int.MaxValue;

	for (int i = 11; i < 1000; i += 2)
	{

		//Only 1,3,7,9 are valid endings
		if (i % 5 == 0) continue;

		int[][] patterns = (i < 100) ?
			fiveDigitPattern : sixDigitPattern;

		for (int j = 0; j < patterns.GetLength(0); j++)
		{
			for (int k = 0; k <= 2; k++)
			{

				//Don't generate candidates with leading zero
				if (patterns[j][0] == 0 && k == 0) continue;

				int[] pattern = fillPattern(patterns[j], i);
				int candidate = generateNumber(k, pattern);

				if (candidate < result && isPrime(candidate))
				{
					if (familySize(k, pattern) == 8)
						result = candidate;
					break;
				}
			}
		}
	}
	
	result.Dump();
}

// Define other methods and classes here
private int[][] get5digitPatterns()
{
	int[][] retVal = new int[4][];

	retVal[0] = new int[] { 1, 0, 0, 0, 1 };
	retVal[1] = new int[] { 0, 1, 0, 0, 1 };
	retVal[2] = new int[] { 0, 0, 1, 0, 1 };
	retVal[3] = new int[] { 0, 0, 0, 1, 1 };

	return retVal;
}

private int[][] get6digitPatterns()
{
	int[][] retVal = new int[10][];

	retVal[0] = new int[] { 1, 1, 0, 0, 0, 1 };
	retVal[1] = new int[] { 1, 0, 1, 0, 0, 1 };
	retVal[2] = new int[] { 1, 0, 0, 1, 0, 1 };
	retVal[3] = new int[] { 1, 0, 0, 0, 1, 1 };
	retVal[4] = new int[] { 0, 1, 1, 0, 0, 1 };
	retVal[5] = new int[] { 0, 1, 0, 1, 0, 1 };
	retVal[6] = new int[] { 0, 1, 0, 0, 1, 1 };
	retVal[7] = new int[] { 0, 0, 1, 1, 0, 1 };
	retVal[8] = new int[] { 0, 0, 1, 0, 1, 1 };
	retVal[9] = new int[] { 0, 0, 0, 1, 1, 1 };

	return retVal;
}

private int[] fillPattern(int[] pattern, int number)
{
	int[] filledPattern = new int[pattern.Length];
	int temp = number;

	for (int i = filledPattern.Length - 1; 0 <= i; i--)
	{
		if (pattern[i] == 1)
		{
			filledPattern[i] = temp % 10;
			temp /= 10;
		}
		else
		{
			filledPattern[i] = -1;
		}
	}
	return filledPattern;
}

private int generateNumber(int repNumber, int[] filledPattern)
{
	int temp = 0;
	for (int i = 0; i < filledPattern.Length; i++)
	{
		temp = temp * 10;
		temp += (filledPattern[i] == -1) ?
			repNumber : filledPattern[i];
	}
	return temp;
}

private int familySize(int repeatingNumber, int[] pattern)
{
	int familySize = 1;

	for (int i = repeatingNumber + 1; i < 10; i++)
	{
		if (isPrime(generateNumber(i, pattern))) familySize++;
	}

	return familySize;
}

private bool isPrime(int n) {
            if (n <= 1) return false;            
            if (n == 2) return true;            
            if (n % 2 == 0) return false;            
            if (n < 9) return true;            
            if (n % 3 == 0) return false;
            
            int counter = 5;
            while ((counter * counter) <= n) {
                if (n % counter == 0) return false;                
                if (n % (counter + 2) == 0) return false;                
                counter += 6;
            }

	return true;
}
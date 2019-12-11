<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var primes = ESieve(1000000);

	for (var i = 9; i < 1000000; i += 2)
	{
		if (primes.Contains(i))
			continue;

		var isNotGoldback = true;
		foreach (var p in primes.Where(x => x < i))
		{
			var square = Math.Sqrt((i - p) / 2);
			if (square == (int)square)
			{
				isNotGoldback = false;
				break;
			}
		}

		if (isNotGoldback)
		{
			i.Dump();
			break;
		}
	}
}

// Define other methods and classes here
public int[] ESieve(int upperLimit)
{
	int sieveBound = (int)(upperLimit - 1) / 2;
	int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;

	BitArray PrimeBits = new BitArray(sieveBound + 1, true);

	for (int i = 1; i <= upperSqrt; i++)
	{
		if (PrimeBits.Get(i))
		{
			for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
			{
				PrimeBits.Set(j, false);
			}
		}
	}

	List<int> numbers = new List<int>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));
	numbers.Add(2);

	for (int i = 1; i <= sieveBound; i++)
	{
		if (PrimeBits.Get(i))
		{
			numbers.Add(2 * i + 1);
		}
	}

	return numbers.ToArray();
}
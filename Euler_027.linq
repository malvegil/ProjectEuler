<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var primes = ESieve(50000);
	var max_n = 0;
	var max_p = 0;
	for (var a = -999; a < 1000; a++)
	{
		for (var b = -999; b < 1000; b++)
		{
			var n = 0;
			while (primes.Contains((n * n) + (a * n) + b))
			{
				n++;
			}
			if (n > max_n)
			{
				max_n = n;
				max_p = a * b;
			}
		}
	}

	max_n.Dump();
	max_p.Dump();
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
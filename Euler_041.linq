<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var primes = ESieve(987654321);
	var max = 1;
	foreach (var p in primes)
	{
		if (p > 1000000 && isPandigital(p))
			max = Math.Max(p, max);
	}

	max.Dump();
}

// Define other methods and classes here
private bool isPandigital(long n)
{
	int digits = 0;
	int count = 0;
	int tmp;

	while (n > 0)
	{
		tmp = digits;
		digits = digits | 1 << (int)((n % 10) - 1);
		if (tmp == digits)
		{
			return false;
		}

		count++;
		n /= 10;
	}
	return digits == (1 << count) - 1;
}

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
<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	const int limit = 1000000;
	long[] primes = ESieve(1, limit);
	
	var max_count = 0;
	long max_prime = 0;
	var prime_sum = new long[primes.Length + 1];
	prime_sum[0] = 0;

	for (var i = 0; i < primes.Count(); i++)
	{
		prime_sum[i + 1] = prime_sum[i] + primes[i];
	}

	for (var i = max_count; i < prime_sum.Length; i++)
	{
		for (var j = i - (max_count + 1); j >= 0; j--)
		{
			if (prime_sum[i] - prime_sum[j] > limit) break;

			if (Array.BinarySearch(primes, prime_sum[i] - prime_sum[j]) >= 0)
			{
				max_count = i - j;
				max_prime = prime_sum[i] - prime_sum[j];
			}
		}
	}

	max_count.Dump();
	max_prime.Dump();
}

// Define other methods and classes here
public long[] ESieve(int lowerLimit, int upperLimit)
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

	List<long> numbers = new List<long>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));

	if (lowerLimit < 3)
	{
		numbers.Add(2);
		lowerLimit = 3;
	}

	for (int i = (lowerLimit - 1) / 2; i <= sieveBound; i++)
	{
		if (PrimeBits.Get(i))
		{
			numbers.Add(2 * i + 1);
		}
	}

	return numbers.ToArray();
}
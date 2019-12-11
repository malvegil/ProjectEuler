<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var primes = ESieve(1000000);
	var previous_1 = 0;
	var previous_2 = 0;
	var previous_3 = 0;
	for (var i = 100000; i < 1000000; i++)
	{
		var current = GetPrimeFactorCount(i, primes.ToList());
		if (current == 4 && previous_1 == i - 3 && previous_2 == i - 2 && previous_3 == i - 1)
		{
			previous_1.Dump();
			break;
		}
		if (current == 4)
		{
			previous_1 = previous_2;
			previous_2 = previous_3;
			previous_3 = i;
		}
	}
}

// Define other methods and classes here
public int GetPrimeFactorCount(int val, List<int> primes)
{
	var count = 0;
	var last_prime = 0;
	foreach (var p in primes)
	{
		if (val % p == 0 && p != last_prime)
		{
			last_prime = p;
			count++;
			while (val % p == 0)
				val /= p;
		}
	}

	return count;
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
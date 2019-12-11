<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var primes = ESieve(1000000);

	var circular = new List<int>();
	var prime_arrays = new int[primes.Length][];

	for (var p = 0; p < primes.Length; p++)
	{
		var val_array = new List<int>();
		var val = primes[p];
		var count = 0;
		while (val > 0)
		{
			val_array.Add(val % 10);
			val /= 10;
			count++;
		}
		prime_arrays[p] = val_array.ToArray();
	}

	for (var i = 1; i < 10; i++)
	{
		var prime_digits = prime_arrays.Where(pa => pa.Count() == i && !pa.Any(z => new int[] { 0, 2, 4, 6, 5, 8 }.Contains(z)));
		if (i == 1)
		{
			foreach (var p in prime_arrays.Where(pa => pa.Count() == i))
				circular.Add(p[0]);
		}
		else if (i == 2)
		{
			foreach (var p in prime_digits)
			{
				if (prime_digits.Any(z => z[0] == p[1] && z[1] == p[0]))
				{
					circular.Add(p[0] + p[1] * 10);
				}
			}
		}
		else
		{
			foreach (var p in prime_digits)
			{
				var z = 0;
				for (var x = 0; x < i; x++)
				{
					z += p[x] * ((int)Math.Pow(10, x));
				}

				if (circular.Contains(z))
					continue;

				var y = z;
				var count = 1;
				var checks = new List<int>();
				checks.Add(z);
				for (var ww = 0; ww < i - 1; ww++)
				{
					y = ((y % 10) * (int)Math.Pow(10, i - 1)) + (y / 10);
					if (primes.Contains(y))
					{
						count++;
						checks.Add(y);
					}
				}

				if (count == i)
				{
					circular.AddRange(checks);
				}
			}
		}
	}

	circular.Count.Dump();
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
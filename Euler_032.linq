<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var products = new List<long>();
	long sum = 0;
	long prod, compiled;

	for (long m = 2; m < 100; m++)
	{
		long nbegin = (m > 9) ? 123 : 1234;
		long nend = 10000 / m + 1;

		for (long n = nbegin; n < nend; n++)
		{
			prod = m * n;
			compiled = concat(concat(prod, n), m);
			if (compiled >= 1E8 &&
				compiled < 1E9 &&
				isPandigital(compiled))
			{
				if (!products.Contains(prod))
				{
					products.Add(prod);
				}
			}
		}
	}

	for (int i = 0; i < products.Count; i++)
	{
		sum += products[i];
	}
	
	sum.Dump();
}

// Define other methods and classes here
private long concat(long a, long b)
{
	long c = b;
	while (c > 0)
	{
		a *= 10;
		c /= 10;
	}
	return a + b;
}

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
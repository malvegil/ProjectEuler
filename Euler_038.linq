<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	ulong max = 0;
	for (var i = 1; i < 1000000; i++)
	{
		ulong compiled = 0;
		for (var j = 1; j <= 5; j++)
		{
			compiled = concat(compiled, (ulong)(i * j));
			if (isGood(compiled))
				max = Math.Max(max, compiled);
		}
	}
	max.Dump();
}

// Define other methods and classes here
private ulong concat(ulong a, ulong b)
{
	ulong c = b;
	while (c > 0)
	{
		a *= 10;
		c /= 10;
	}
	return a + b;
}

private bool isPandigital(ulong n)
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

private bool isGood(ulong compiled)
{
	return (compiled >= 1E8 &&
		compiled < 1E9 &&
		isPandigital(compiled));
}
<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	long closest = 10000000000;

	for (var p1 = 1; p1 < 10000; p1++)
	{
		var pent1 = (long)p1 * (long)(3 * p1 - 1) / 2;
		for (var p2 = p1 - 1; p2 > 0; p2--)
		{
			var pent2 = (long)p2 * (long)(3 * p2 - 1) / 2;

			if (!IsPentagonal(pent1 - pent2) || !IsPentagonal(pent1 + pent2))
				continue;

			closest = Math.Min(closest, pent1 - pent2);
		}
	}

	closest.Dump();
}

// Define other methods and classes here
private bool IsPentagonal(long val)
{
	var x = (Math.Sqrt((24 * val) + 1) + 1.0) / 6.0;
	return (x == (int)x);
}
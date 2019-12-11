<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var chain_total = 0;
	ulong chain_i = 0;

	for (ulong i = 837799 ; i <= 837799 ; i++)
	{
		int local_total = 1;
		ulong start = i;
		while (start > 1)
		{
			local_total++;
			start = (start % 2 == 0) ?
				start / 2 :
				(3 * start) + 1;
		}

		if (local_total > chain_total)
		{
			chain_i = i;
			chain_total = local_total;
		}
	}

	chain_i.Dump();
	chain_total.Dump();
}

// Define other methods and classes here

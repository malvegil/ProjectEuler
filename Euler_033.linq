<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

var num = 1;
var den = 1;

for (var n = 10; n < 100; n++)
{
	for (var d = n + 1; d < 100; d++)
	{
		var x = ((double)n / d);

		if (n % 10 == 0 && d % 10 == 0)
			continue;

		if (n % 10 == d / 10)
		{
			if ((double)(n / 10) / (d % 10) == x)
			{
				n.Dump();
				d.Dump();
				Console.WriteLine();
				num *= n;
				den *= d;
			}
		}
		else if (n / 10 == d % 10)
		{
			if ((double)(n % 10) / (d / 10) == x)
			{
				n.Dump();
				d.Dump();
				Console.WriteLine();
				num *= n;
				den *= d;
			}
		}
	}
}

num.Dump();
den.Dump();

<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

var sum = 0;

for (var i = 2; i < 250000; i++)
{
	var inner_sum = 0;
	var value = i;
	while (value > 0)
	{
		inner_sum += (int)Math.Pow(value % 10, 5);
		value /= 10;
	}

	if (inner_sum == i)
		sum += inner_sum;
}

sum.Dump();
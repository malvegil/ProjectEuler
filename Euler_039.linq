<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

var max_p = 0;
var max_count = 0;
for (var p = 3; p <= 1000; p++)
{
	var count = 0;
	for (var a = 1; a <= p - 2; a++)
	{
		for (var b = 1; b <= p - a - 1; b++)
		{
			var c = p - a - b;
			if (a * a + b * b == c * c)
				count++;
		}
	}

	if (count > max_count)
	{
		max_p = p;
		max_count = count;
	}
}

max_count.Dump();
max_p.Dump();
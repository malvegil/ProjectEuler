<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

var find = 1000;

for (var a = 1; a < find; a++)
{
	for (var b = a + 1; b < find - a; b++)
	{
		for (var c = b + 1; c < find - b; c++)
		{
			if (a + b + c == find &&
				a * a + b * b == c * c)
			{
				a.Dump();b.Dump();c.Dump();
				(a * b * c).Dump();
			}
		}
	}
}
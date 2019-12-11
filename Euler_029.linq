<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

var terms = new List<double>();
for (var a = 2; a <= 100; a++)
{
	for (var b = 2; b <= 100; b++)
	{
		terms.Add(Math.Pow(a, b));
	}
}

terms.Distinct().Count().Dump();
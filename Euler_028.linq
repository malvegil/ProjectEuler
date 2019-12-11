<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var sum = 1;
	var last = 1;
	for (var i = 2; i <= 1001; i += 2)
	{
		for (var j = 1; j <= 4; j++)
		{
			last += i;
			sum += last;
		}
	}

	sum.Dump();
}

// Define other methods and classes here

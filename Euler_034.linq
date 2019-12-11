<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var facts = new int[10];
	for (var i = 0; i < 10; i++)
	{
		facts[i] = GetFactorial(i);
	}

	var total = 0;

	for (var i = 3; i < 50000; i++)
	{
		var sum = 0;
		var val = i;
		while (val > 0)
		{
			sum += facts[val % 10];
			val /= 10;
		}

		if (sum == i)
			total += sum;
	}
	
	total.Dump();
}

// Define other methods and classes here
private int GetFactorial(int value)
{
	if (value <= 1)
		return 1;

	return value * GetFactorial(value - 1);
}
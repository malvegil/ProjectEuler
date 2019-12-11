<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var factorial = 100;
	var digits = new int[factorial * 2];
	digits[0] = 1;
	for (var i = 1; i <= factorial; i++)
	{
		var carry = 0;
		for (var j = 0; j < factorial * 2; j++)
		{
			var x = digits[j] * i + carry;
			digits[j] = x % 10;
			carry = x / 10;
		}
	}
	digits.Dump();
	digits.Sum().Dump();

	GetFactorial(100).Dump();
}

// Define other methods and classes here
public static ulong GetFactorial(ulong val)
{
	if (val == 1)
		return val;
	else
		return val * GetFactorial(val - 1);
}
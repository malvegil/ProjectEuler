<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var max = 0;
	for (var x = 999; x >= 100; x--)
	{
		for (var y = 999; y >= 100; y--)
		{
			if (x * y < max) break;
			
			if (IsPalindrome(x * y))
				max = Math.Max(max, x * y);
		}
	}

	Console.WriteLine(string.Format("product: {0}", max));


	max = 0;
	var a = 999;
	while (a >= 100)
	{
		var b = 999;
		while (b >= a)
		{
			if (a * b <= max)
				break; //Since a*b is always going to be too small
			if (IsPalindrome(a * b))
				max = a * b;
			b--;
		}
		a--;
	}
	Console.WriteLine(string.Format("product: {0}", max));
}

// Define other methods and classes here
public static bool IsPalindrome(int p)
{
	return p == Reverse(p);
}

public static int Reverse(int p)
{
	var reversed = 0;
	while (p > 0)
	{
		reversed = 10 * reversed + p % 10;
		p = p / 10;
	}
	return reversed;
}
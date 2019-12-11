<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	int sum = 0;
	for (int i = 1; i < 1000000; i += 2)
	{
		if (IsPalindrome(i, 10) && IsPalindrome(i, 2))
			sum += i;
	}

	sum.Dump();
}

// Define other methods and classes here
public static bool IsPalindrome(int p, int b)
{
	var reversed = 0;
	var k = p;
	while (k > 0)
	{
		reversed = b * reversed + k % b;
		k = k / b;
	}
	return p == reversed;
}

public static ulong CreateBitulong(ulong p)
{
	ulong ret = 0;
	var count = 0;
	while (p != 0)
	{
		ret += (p & 1) * (ulong)Math.Pow(10, count);
		p >>= 1;
		count++;
	}

	return ret;
}
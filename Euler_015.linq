<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var paths = GetBinCoeff(40, 20);
	paths.Dump();
	
	paths = countRoutes(20, 20);
	paths.Dump();
}

// Define other methods and classes here
public static long GetBinCoeff(long N, long K)
{
	// This function gets the total number of unique combinations based upon N and K.
	// N is the total number of items.
	// K is the size of the group.
	// Total number of unique combinations = N! / ( K! (N - K)! ).
	// This function is less efficient, but is more likely to not overflow when N and K are large.
	// Taken from:  http://blog.plover.com/math/choose.html
	//
	long r = 1;
	long d;
	if (K > N) return 0;
	for (d = 1; d <= K; d++)
	{
		r *= N--;
		r /= d;
	}
	return r;
}

public static long countRoutes(long n, long k)
{
	long result = 1;
	for (k = 1; k <= n; k++)
	{
		result = result * (n + k) / k;
	}
	return result;
}
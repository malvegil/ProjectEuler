<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	long result = 0;
	int[] divisors = { 1, 2, 3, 5, 7, 11, 13, 17 };

	int count = 1;
	int numPerm = 3265920;

	while (count < numPerm)
	{
		int N = perm.Length;
		int i = N - 1;
		while (perm[i - 1] >= perm[i])
		{
			i = i - 1;
		}

		int j = N;
		while (perm[j - 1] <= perm[i - 1])
		{
			j = j - 1;
		}

		// swap values at position i-1 and j-1
		swap(i - 1, j - 1);

		i++;
		j = N;
		while (i < j)
		{
			swap(i - 1, j - 1);
			i++;
			j--;
		}
		bool divisible = true;
		for (int k = 1; k < divisors.Length; k++)
		{
			int num = 100 * perm[k] + 10 * perm[k + 1] + perm[k + 2];
			if (num % divisors[k] != 0)
			{
				divisible = false;
				break;
			}
		}
		if (divisible)
		{
			long num = 0;
			for (int k = 0; k < perm.Length; k++)
			{
				num = 10 * num + perm[k];
			}
			result += num;
		}
		count++;
	}
	
	result.Dump();
}

// Define other methods and classes here
private int[] perm = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

private int Factor(int i)
{
	if (i < 0)
	{
		return 0;
	}

	int p = 1;
	for (int j = 1; j <= i; j++)
	{
		p *= j;
	}
	return p;
}

private void swap(int i, int j)
{
	int k = perm[i];
	perm[i] = perm[j];
	perm[j] = k;
}
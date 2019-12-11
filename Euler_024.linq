<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	int[] perm = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
	int N = perm.Length;
	string permNum = "";
	int remain = 1000000 - 1;

	List<int> numbers = new List<int>();
	for (int i = 0; i < N; i++)
	{
		numbers.Add(i);
	}

	for (int i = 1; i < N; i++)
	{
		int j = remain / Factorial(N - i);
		remain = remain % Factorial(N - i);
		permNum = permNum + numbers[j];
		numbers.RemoveAt(j);
		if (remain == 0)
		{
			break;
		}
	}

	for (int i = 0; i < numbers.Count; i++)
	{
		permNum = permNum + numbers[i];
	}

	permNum.Dump();
}

// Define other methods and classes here
private static int Factorial(int value)
{
	if (value == 1)
		return 1;

	return value * Factorial(value - 1);
}
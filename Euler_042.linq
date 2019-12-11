<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var input = File.ReadAllLines(@"C:\Users\chris.esau\Desktop\p042_words.txt");
	var words = input[0].Replace("\"", "").Split(',');
	var longest_length = words.OrderByDescending(x => x.Length).First().Length;
	var triangle_numbers = GetTriangleNumbers(longest_length * 26);

	var triangle_count = 0;
	foreach (var word in words)
	{
		var sum = 0;
		for (var i = 0; i < word.Length; i++)
		{
			sum += (int)word[i] - 64;
		}

		if (triangle_numbers.Contains(sum))
			triangle_count++;
	}
	
	triangle_count.Dump();
}

// Define other methods and classes here
private List<int> GetTriangleNumbers(int limit)
{
	return (Enumerable.Range(1, limit)
			.Select(x => (x * (x + 1)) / 2).ToList());
}
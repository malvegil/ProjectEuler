<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var input = File.ReadAllLines(@"C:\Users\chris.esau\Desktop\p067_triangle.txt");

	var size = input.Length;
	int[][] grid = new int[size][];
	for (var y = 0; y < size; y++)
	{
		var line = input[y].Split();
		grid[y] = new int[y + 1];
		for (var x = 0; x <= y; x++)
		{
			grid[y][x] = Int32.Parse(line[x]);
		}
	}

	for (var y = size - 1; y > 0; y--)
	{
		for (var x = 0; x < y; x++)
		{
			grid[y - 1][x] += Math.Max(grid[y][x], grid[y][x + 1]);
		}
	}

	grid[0][0].Dump();
}

// Define other methods and classes here

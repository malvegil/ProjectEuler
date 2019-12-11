<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var not_found = true;
	var i = 40755;

	while (not_found)
	{
		i++;
		if (IsTriangularPentagonalHexagonal(i))
			not_found = false;
	}
	
	i.Dump();
}

// Define other methods and classes here
public bool IsTriangularPentagonalHexagonal(long val)
{
	var tri = (Math.Sqrt((8 * val) + 1) - 1.0) / 2.0;
	if (tri != (int)tri)
		return false;

	var pent = (Math.Sqrt((24 * val) + 1) + 1.0) / 6.0;
	if (pent != (int)pent)
		return false;

	var hex = (Math.Sqrt((8 * val) + 1) + 1.0) / 4.0;
	if (hex != (int)hex)
		return false;

	return true;
}
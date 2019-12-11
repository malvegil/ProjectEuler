<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var primes = ESieve(9999).Where(x => x >= 1000).ToList();
	foreach (var p in primes)
	{
		var perms = GetPermutations(p);

		var matches = primes.Where(x => perms.Contains(x)).OrderBy(x => x).ToArray();

		if (matches.Count() >= 3)
		{
			var diffs = new List<Match>();
			for (var i = 0; i < matches.Count(); i++)
			{
				for (var j = matches.Count() - 1; j > i; j--)
				{
					diffs.Add(new Match() { Diff = matches[j] - matches[i], Term1 = matches[i], Term2 = matches[j] });
				}
			}

			foreach (var d in diffs)
			{
				if (diffs.Any(z => z.Term2 == d.Term1 && z.Diff == d.Diff))
				{
					diffs.Where(z => z.Diff == d.Diff).Dump();
					break;
				}
			}
		}
	}
}

// Define other methods and classes here
public class Match
{
	public int Diff { get; set; }
	public int Term1 { get; set; }
	public int Term2 { get; set; }
}
public List<int> GetPermutations(int value)
{
	var digits = new int[4];
	for (var i = 3; i >= 0; i--)
	{
		digits[i] = value % 10;
		value /= 10;
	}

	var perms = new List<int>();
	for (var i = 0; i < 4; i++)
	{
		for (var j = 0; j < 4; j++)
		{
			if (i == j)
				continue;

			for (var k = 0; k < 4; k++)
			{
				if (i == k || j == k)
					continue;

				for (var l = 0; l < 4; l++)
				{
					if (i == l || j == l || k == l)
						continue;

					perms.Add((digits[i] * 1000) + (digits[j] * 100) + (digits[k] * 10) + (digits[l]));
				}
			}
		}
	}

	return perms;
}

public int[] ESieve(int upperLimit)
{
	int sieveBound = (int)(upperLimit - 1) / 2;
	int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;

	BitArray PrimeBits = new BitArray(sieveBound + 1, true);

	for (int i = 1; i <= upperSqrt; i++)
	{
		if (PrimeBits.Get(i))
		{
			for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
			{
				PrimeBits.Set(j, false);
			}
		}
	}

	List<int> numbers = new List<int>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));
	numbers.Add(2);

	for (int i = 1; i <= sieveBound; i++)
	{
		if (PrimeBits.Get(i))
		{
			numbers.Add(2 * i + 1);
		}
	}

	return numbers.ToArray();
}
<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var primes = ESieve(1000000);

	//var e = new Eratosthenes();

	var count = 0;
	var sum = 0;

	foreach (var p in primes)
	{
		if (p / 10 == 0)
			continue;

		var rl = p;
		var power = 0;
		while (rl != 0)
		{
			if (!primes.Contains(rl))
				break;
			rl /= 10;
			power++;
		}

		if (rl == 0)
		{
			var lr = p;

			for (var d = (int)Math.Pow(10d, power - 1); d >= 1; d /= 10)
			{
				if (!primes.Contains(lr))
					break;

				lr %= d;
			}

			if (lr == 0)
			{
				count++;
				sum += p;
			}
		}


		if (count == 15)
			break;
	}
	
	sum.Dump();
}

// Define other methods and classes here
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

public class Eratosthenes : IEnumerable<int>
{
	private static List<int> _primes = new List<int>();
	private int _lastChecked;

	public Eratosthenes()
	{
		_primes.Add(2);
		_lastChecked = 2;
	}

	private bool IsPrime(int checkValue)
	{
		bool isPrime = true;

		foreach (int prime in _primes)
		{
			if ((checkValue % prime) == 0 && prime <= Math.Sqrt(checkValue))
			{
				isPrime = false;
				break;
			}
		}

		return isPrime;
	}

	public IEnumerator<int> GetEnumerator()
	{
		foreach (int prime in _primes)
		{
			yield return prime;
		}

		while (_lastChecked < int.MaxValue)
		{
			_lastChecked++;

			if (IsPrime(_lastChecked))
			{
				_primes.Add(_lastChecked);
				yield return _lastChecked;
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
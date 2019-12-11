<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var limit = 10001;
	List<int> primes = new List<int>();
	Eratosthenes eratosthenes = new Eratosthenes();

	foreach (int prime in eratosthenes)
	{
		primes.Add(prime);
		if (primes.Count == limit)
			break;
	}

	primes.Max().Dump();
	
	
	primes.Clear();
	var candidate = 1;
	primes.Add(2); //already known as prime
	while (primes.Count() < limit)
	{
		candidate = candidate + 2;
		if (IsPrime(candidate)) primes.Add(candidate);
	}
	
	primes.Max().Dump();
}

// Define other methods and classes here
public static bool IsPrime(int n)
{
	if (n == 1) return false;
	else
	if (n < 4) return true; //2 and 3 are prime
	else
	if (n % 2 == 0) return false; //evens are not prime
	else
	if (n < 9) return true; //we have already excluded 4,6 and 8.
	else
	if (n % 3 == 0) return false;
	else
	{
		var r = (int)(Math.Sqrt(n)); // sqrt(n) rounded to the greatest integer r so that r*r<=n
		var f = 5;
		while (f <= r)
		{
			if (n % f == 0) return false;
			if (n % (f + 2) == 0) return false;
			f = f + 6;
		}
		return true;
	}
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
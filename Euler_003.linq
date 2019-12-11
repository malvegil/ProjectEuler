<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>System.Collections</Namespace>
</Query>

void Main()
{
	//Euler 003
	//largest prime factor of 600851475143

	var input = 600851475143;

	Eratosthenes eratosthenes = new Eratosthenes();

	IEnumerable<int> factors = GetPrimeFactors(input, eratosthenes);

	foreach (int i in factors)
	{
		Console.Write("{0} ", i); 
	}


	var lastFactor = 1;
	var n = input;
	if (n % 2 == 0)
	{
		lastFactor = 2;
		n = n / 2;
		while (n % 2 == 0)
		{ n = n / 2; }
	}
	else
		lastFactor = 1;
	var factor = 3;
	var maxFactor = (int)Math.Sqrt(n);
	while (n > 1 && factor <= maxFactor)
	{
		if (n % factor == 0)
		{
			n = n / factor;
			lastFactor = factor;
			while (n % factor == 0)
			{ n = n / factor; }
			maxFactor = (int)Math.Sqrt(n);
			factor = factor + 2;
		}
		if (n == 1)
			lastFactor.Dump();
		else
			n.Dump();
	}
}

// Define other methods and classes here
private static IEnumerable<int> GetPrimeFactors(long value, Eratosthenes eratosthenes)
{
	List<int> factors = new List<int>();

	foreach (int prime in eratosthenes)
	{
		while (value % prime == 0)
		{
			value /= prime;
			factors.Add(prime);
		}

		if (value == 1)
		{
			break;
		}
	}

	return factors;
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
<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	//Problem 21

	//Let d(n) be defined as the sum of proper divisors of n(numbers less than n which divide evenly into n).
	//If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
	//
	//For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284.The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
	//
	//Evaluate the sum of all the amicable numbers under 10000.

	var limit = 10000;
	var primes = GetPrimeNumbers(limit, new Eratosthenes());
	var list = new List<int>();

	for (var i = 2; i <= limit; i++)
	{
		if (primes.Contains(i) || list.Contains(i))
			continue;

		var f1 = GetProperFactors(i).Sum();
		var f2 = GetProperFactors(f1).Sum();

		if (f2 == i && f2 != f1)
		{
			list.Add(i);
			list.Add(f2);
		}
	}

	list.Distinct().Sum().Dump();
}

// Define other methods and classes here
private static List<int> GetProperFactors(int value)
{
	var factors = new List<int>();
	factors.Add(1);

	for (var i = 2; i <= Math.Sqrt(value); i++)
	{
		if (value % i == 0)
		{
			factors.Add(i);
			factors.Add(value / i);
		}
	}

	return factors;
}

private static IEnumerable<int> GetPrimeNumbers(int value, Eratosthenes eratosthenes)
{
	List<int> primes = new List<int>();

	foreach (int prime in eratosthenes)
	{
		if (prime < value)
			primes.Add(prime);
		else
			break;
	}

	return primes;
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
<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	int n = 3; //start with a prime
	int Dn = 2; //number of divisors for any prime
	int cnt = 0; //to insure the while loop is entered
	int n1, Dn1, i, exponent;
	var e = new Eratosthenes();
	var P = 65500;
	var primearray = GetPrimeNumbers(P, e).ToArray();

	while (cnt <= 500)
	{
		n = n + 1;
		n1 = n;
		if (n1 % 2 == 0) n1 = n1 / 2;
		Dn1 = 1;
		for (i = 0; i < P; i++)
		{
			//If your array indexing starts at 0, change to i=0 and i<P
			if (primearray[i] * primearray[i] > n1)
			{ Dn1 = 2 * Dn1; break; }
			//When the prime divisor would be greater than the residual n1,
			//that residual n1 is the last prime factor with an exponent=1
			//No necessity to identify it.
			exponent = 1;
			while (n1 % primearray[i] == 0)
			{
				exponent++;
				n1 = n1 / primearray[i];
			}
			if (exponent > 1) Dn1 = Dn1 * exponent;
			if (n1 == 1) break;
		}
		cnt = Dn * Dn1;
		Dn = Dn1;
	}
	(n * (n - 1) / 2).Dump();
}

// Define other methods and classes here
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
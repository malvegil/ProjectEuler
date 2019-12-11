<Query Kind="Program">
  <Connection>
    <ID>b9bd739a-fa2b-4350-87d2-e71685f3121a</ID>
    <Persist>true</Persist>
    <Driver>LinqToSql</Driver>
    <Server>apexsqldev02</Server>
    <CustomAssemblyPath>P:\CorpIT\.NET Libraries\Production ARI DLLs\ApexDataModel.dll</CustomAssemblyPath>
    <CustomTypeName>ApexRemington.DAL.rempscoDataContext</CustomTypeName>
    <Database>compass_dev</Database>
    <DisplayName>ARI - Dev</DisplayName>
  </Connection>
  <Output>DataGrids</Output>
</Query>

void Main()
{
	int input = 20;
	long mincom = 1;

	Eratosthenes eratosthenes = new Eratosthenes();
	IEnumerable<int> primes = GetPrimeNumbers(input, eratosthenes);

	foreach (int i in primes)
	{
		long x = i;
		while (x <= input)
		{
			x *= i;
		}
		mincom *= x / i;
	}

	mincom.Dump();
}

// Define other methods and classes here
private static IEnumerable<int> GetPrimeNumbers(long value, Eratosthenes eratosthenes)
{
	List<int> primes = new List<int>();

	foreach (int prime in eratosthenes)
	{
		if (prime <= value)
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
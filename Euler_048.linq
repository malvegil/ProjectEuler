<Query Kind="Statements">
  <Output>DataGrids</Output>
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>

var digits = new int[10];
for (int i = 1; i <= 1000; i++)
{
	var x = BigInteger.Pow(i, i);
	var carry = 0;
	for (var j = 0; j < 10; j++)
	{
		var to_add = (int)(x % 10) + carry + digits[j];
		digits[j] = to_add % 10;
		carry = to_add / 10;
		x /= 10;
	}
}

digits.Dump();

long result = 0;
long modulo = 10000000000;

for (int i = 1; i <= 1000; i++)
{
	long temp = i;
	for (int j = 1; j < i; j++)
	{
		temp *= i;
		if (temp >= long.MaxValue / 1000)
		{
			temp %= modulo;
		}
	}

	result += temp;
	result %= modulo;
}

result.Dump();
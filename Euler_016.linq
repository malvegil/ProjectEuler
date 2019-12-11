<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

var power = 1000;
var digits = new int[power / 2];
digits[0] = 2;
for (var i = 1; i < power; i++)
{
	var carry = 0;
	for (var j = 0; j < power / 2; j++)
	{
		var x = digits[j] * 2 + carry;
		digits[j] = x % 10;
		carry = x / 10;
	}
}

digits.Sum().Dump();
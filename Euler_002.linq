<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

//Euler 002
//sum of all even Fibonacci sequence values less than 4000000

var sum = 0;
var first = 1;
var second = 1;
var l = 4000000;
var third = 0;

while (second < l)
{
	if (second % 2 == 0)
		sum += second;

	third = first + second;
	first = second;
	second = third;
}

sum.Dump();

//no testing model
sum = 0;
first = 1;
second = 1;
third = first + second;
while (third < l)
{
	sum += third;
	first = second + third;
	second = third + first;
	third = first + second;
}
sum.Dump();
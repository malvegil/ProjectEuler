<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

//Euler 019

//You are given the following information, but you may prefer to do some research for yourself.
//
//1 Jan 1900 was a Monday.
//Thirty days has September,
//April, June and November.
//All the rest have thirty - one,
//Saving February alone,
//Which has twenty - eight, rain or shine.
//And on leap years, twenty - nine.
//A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
//How many Sundays fell on the first of the month during the twentieth century(1 Jan 1901 to 31 Dec 2000) ?

var day_count = 0;
var first_sunday = 0;
for (var y = 0; y <= 100; y++)
{
	for (var m = 1; m <= 12; m++)
	{
		if ((day_count + 1) % 7 == 0 && y != 0)
			first_sunday++;

		switch (m)
		{
			case 2:
				day_count += (y % 4 == 0 && y != 0) ? 29 : 28;
				break;
			case 9:
			case 4:
			case 6:
			case 11:
				day_count += 30;
				break;
			default:
				day_count += 31;
				break;
		}
	}
}

day_count.Dump();
first_sunday.Dump();
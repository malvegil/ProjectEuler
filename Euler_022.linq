<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

var input = File.ReadAllLines(@"C:\Users\chris.esau\Desktop\p022_names.txt");
var names = input[0].Split(',');
var score = 0;
var count = 0;
foreach (var n in names.OrderBy(x => x))
{
	count++;
	var name_score = 0;
	foreach (var c in n.Replace("\"", "").ToCharArray())
	{
		name_score += ((int)c) - 64;
	}
	score += (count * name_score);
}

score.Dump();

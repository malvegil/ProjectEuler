<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

var sb = new StringBuilder();

for (var i = 1; i < 250000; i++)
{
	sb.Append(i.ToString());
}

(
Int32.Parse(sb[0].ToString()) *
Int32.Parse(sb[9].ToString()) *
Int32.Parse(sb[99].ToString()) *
Int32.Parse(sb[999].ToString()) *
Int32.Parse(sb[9999].ToString()) *
Int32.Parse(sb[99999].ToString()) *
Int32.Parse(sb[999999].ToString())).Dump();
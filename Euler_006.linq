<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

var x = Enumerable.Range(1, 100);

var diff = (x.Sum() * x.Sum()) - x.Sum(i => i * i);
diff.Dump();

var limit = 100;
var sum = limit * (limit + 1) / 2;
var sum_sq = (2 * limit + 1) * (limit + 1) * limit / 6;
(sum * sum - sum_sq).Dump();
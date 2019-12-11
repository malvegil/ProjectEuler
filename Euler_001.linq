<Query Kind="Statements">
  <Output>DataGrids</Output>
</Query>

//Euler 001
//sum of all integers less than 1000 divisible by 3 or 5

Enumerable.Range(1, 999).Sum(i => (i % 3 == 0 || i % 5 == 0) ? i : 0).Dump();
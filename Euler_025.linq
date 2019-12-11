<Query Kind="Statements">
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

var digits = 1000;

var f1 = new int[digits];
var f2 = new int[digits];
var fib = new int[digits];
f1[0] = f2[0] = 1;
var count = 2;
while (fib[digits - 1] == 0)
{
	count++;
	var carry = 0;
	for (var i = 0; i < 1000; i++)
	{
		var f = f1[i] + f2[i] + carry;
		fib[i] = f % 10;
		carry = f / 10;

		f1[i] = f2[i];
		f2[i] = fib[i];
	}
}

count.Dump();
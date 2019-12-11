<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var count = 0;
	for (var i = 1; i <= 1000; i++)
	{
		count += ConvertIntToText(i).Replace(" ", "").Replace("-", "").Length;

	}
	count.Dump();
}

// Define other methods and classes here
private static readonly string[] _ones =
		{
			"zero",
			"one",
			"two",
			"three",
			"four",
			"five",
			"six",
			"seven",
			"eight",
			"nine"
		};

private static readonly string[] _teens =
		{
			"ten",
			"eleven",
			"twelve",
			"thirteen",
			"fourteen",
			"fifteen",
			"sixteen",
			"seventeen",
			"eighteen",
			"nineteen"
		};

private static readonly string[] _tens =
		{
			"",
			"ten",
			"twenty",
			"thirty",
			"forty",
			"fifty",
			"sixty",
			"seventy",
			"eighty",
			"ninety"
		};

// US Numbering:
private static readonly string[] _thousands =
		{
			"",
			"thousand",
			"million",
			"billion",
			"trillion",
			"quadrillion"
		};

public static string ConvertIntToText(int value)
{
	string digits, temp;
	bool showThousands = false;
	bool allZeros = true;

	// Use StringBuilder to build result
	var builder = new StringBuilder();
	// Convert integer portion of value to string
	digits = ((long)value).ToString();
	// Traverse characters in reverse order
	for (int i = digits.Length - 1; i >= 0; i--)
	{
		var ndigit = (int)(digits[i] - '0');
		int column = (digits.Length - (i + 1));

		// Determine if ones, tens, or hundreds column
		switch (column % 3)
		{
			case 0:        // Ones position
				showThousands = true;
				if (i == 0)
				{
					// First digit in number (last in loop)
					temp = String.Format("{0} ", _ones[ndigit]);
				}
				else if (digits[i - 1] == '1')
				{
					// This digit is part of "teen" value
					temp = String.Format("{0} ", _teens[ndigit]);
					// Skip tens position
					i--;
				}
				else if (ndigit != 0)
				{
					// Any non-zero digit
					temp = String.Format("{0} ", _ones[ndigit]);
				}
				else
				{
					// This digit is zero. If digit in tens and hundreds
					// column are also zero, don't show "thousands"
					temp = String.Empty;
					// Test for non-zero digit in this grouping
					if (digits[i - 1] != '0' || (i > 1 && digits[i - 2] != '0'))
						showThousands = true;
					else
						showThousands = false;
				}

				// Show "thousands" if non-zero in grouping
				if (showThousands)
				{
					if (column > 0)
					{
						temp = String.Format("{0}{1}{2}",
							temp,
							_thousands[column / 3],
							allZeros ? " " : ", ");
					}
					// Indicate non-zero digit encountered
					allZeros = false;
				}
				builder.Insert(0, temp);
				break;

			case 1:        // Tens column
				if (ndigit > 0)
				{
					temp = String.Format("{0}{1}",
						_tens[ndigit],
						(digits[i + 1] != '0') ? "-" : " ");
					builder.Insert(0, temp);
				}
				break;

			case 2:        // Hundreds column
				if (ndigit > 0)
				{
					temp = String.Format("{0} hundred {1}",
					_ones[ndigit],
					(digits[i + 1] != '0' || digits[i + 2] != '0') ? "and " : "");
					builder.Insert(0, temp);
				}
				break;
		}
	}

	// Capitalize first letter
	return
		builder.ToString();
}

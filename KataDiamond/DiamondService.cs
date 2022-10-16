using System.Text;

namespace KataDiamond;

internal sealed class DiamondService
{
    private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public string[] Generate(char letter)
    {
        // Calculate some values to help clean up below
        var letterPosition = char.ToUpper(letter) - 64;
        var rowCount = letterPosition * 2 - 1;
        var centerPosition = rowCount - letterPosition + 1;

        var sidePadding = rowCount - letterPosition;
        var centerPadding = -1;

        var rows = new string[rowCount];

        // 'A' is printed differently, it only has a single character on the line
        var rowData = WriteARow(sidePadding);
        rows[0] = rowData;
        rows[rowCount - 1] = rowData; // Will be the same row if A is sent

        // iterate 
        for (var i = 1; i < letterPosition; i++)
        {
            // Update padding sizes
            sidePadding--;
            centerPadding += 2;

            rowData = WriteRow(i, sidePadding, centerPadding);
            rows[i] = rowData;

            // If it is the center, only one entry is needed.
            if (i + 1 != centerPosition)
            {
                rows[rowCount - i - 1] = rowData;
            }
        }

        return rows;
    }

    public void PrintDiamond(IEnumerable<string> items)
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }


    private static string WriteARow(int sidePadding)
    {
        StringBuilder sb = new();
        sb.Append("".PadLeft(sidePadding));
        sb.Append(Letters[0]);
        sb.Append("".PadLeft(sidePadding));

        return sb.ToString();
    }

    private static string WriteRow(int letterIndex, int sidePadding, int centerPadding)
    {
        StringBuilder sb = new();
        sb.Append("".PadLeft(sidePadding));
        sb.Append(Letters[letterIndex]);
        sb.Append("".PadLeft(centerPadding));
        sb.Append(Letters[letterIndex]);
        sb.Append("".PadLeft(sidePadding));

        return sb.ToString();
    }
}
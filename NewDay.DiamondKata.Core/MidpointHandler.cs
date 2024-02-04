namespace NewDay.DiamondKata.Core;

public class MidpointHandler : IMidpointHandler
{
    private const int MaxRangeAscii = 90;
    private const int MinRangeAscii = 65;

    public bool IsInRange(char midpoint)
    {
        var ascii = (int)midpoint;

        return ascii is >= MinRangeAscii and <= MaxRangeAscii;
    }

    public char[] CreateRangeUpTo(char midpoint)
    {
        if (!IsInRange(midpoint))
        {
            return Array.Empty<char>();
        }

        var intRange = Enumerable.Range(65, midpoint - 65 + 1);

        return intRange.Select(x => (char)x).ToArray();
    }
}
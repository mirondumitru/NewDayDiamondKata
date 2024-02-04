namespace NewDay.DiamondKata.Core;

public class MidpointValidator : IMidpointValidator
{
    private const int MaxRangeAscii = 90;
    private const int MinRangeAscii = 65;

    public bool IsValid(char midpoint)
    {
        var ascii = (int)midpoint;

        return ascii is >= MinRangeAscii and <= MaxRangeAscii;
    }
}
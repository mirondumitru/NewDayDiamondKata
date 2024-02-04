namespace NewDay.DiamondKata.Core;

public class MidpointValidator : IMidpointValidator
{
    private readonly int _maxAscii = 90;
    private readonly int _minAscii = 65;

    public bool IsValid(char midpoint)
    {
        var ascii = (int)midpoint;

        return _minAscii <= ascii && ascii <= _maxAscii;
    }
}
namespace NewDay.DiamondKata.Core;

public class BlankCharProvider : IBlankCharProvider
{
    public BlankCharProvider(char value)
    {
        Value = value;
    }

    public char Value { get; }
}
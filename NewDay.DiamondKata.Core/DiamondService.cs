namespace NewDay.DiamondKata.Core;

public class DiamondService
{
    private readonly IMidpointHandler _midpointHandler;

    public DiamondService(IMidpointHandler midpointHandler)
    {
        _midpointHandler = midpointHandler;
    }

    public Diamond CreateDiamond(char midpoint)
    {
        if (!_midpointHandler.IsInRange(midpoint))
        {
            throw new ArgumentException($"'{midpoint}' is not a valid midpoint");
        }

        var range = _midpointHandler.CreateRangeUpTo(midpoint);

        return new Diamond(range, ' ');
    }
}   
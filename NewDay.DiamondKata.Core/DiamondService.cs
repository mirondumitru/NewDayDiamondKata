namespace NewDay.DiamondKata.Core;

public class DiamondService
{
    private readonly IMidpointHandler _midpointHandler;
    private readonly IBlankCharProvider _blankCharProvider;

    public DiamondService(IMidpointHandler midpointHandler, IBlankCharProvider blankCharProvider)
    {
        _midpointHandler = midpointHandler;
        _blankCharProvider = blankCharProvider;
    }

    public Diamond CreateDiamond(char midpoint)
    {
        if (!_midpointHandler.IsInRange(midpoint))
        {
            throw new ArgumentException($"'{midpoint}' is not a valid midpoint");
        }

        var range = _midpointHandler.CreateRangeUpTo(midpoint);
        var blankChar = _blankCharProvider.Value;

        return new Diamond(range, blankChar);
    }
}
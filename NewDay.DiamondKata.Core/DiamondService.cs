namespace NewDay.DiamondKata.Core;

public class DiamondService
{
    private readonly IMidpointValidator _midpointValidator;

    public DiamondService(IMidpointValidator midpointValidator)
    {
        _midpointValidator = midpointValidator;
    }


    public Diamond CreateDiamond(char midpoint)
    {
        if (!_midpointValidator.IsValid(midpoint))
        {
            throw new ArgumentException($"'{midpoint}' is not a valid midpoint");
        }

        return default;

        //return new Diamond(50);
    }
}   
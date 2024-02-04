namespace NewDay.DiamondKata.Core;

public interface IMidpointHandler
{
    bool IsInRange(char midpoint);

    char[] CreateRangeUpTo(char midpoint);
}
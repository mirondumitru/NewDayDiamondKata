using NewDay.DiamondKata.Core;

if (args.Length == 0)
{
    Console.WriteLine($"{nameof(args)} cannot be empty");
    return;
}

var midpoint = args[0][0];

var service = new DiamondService(new MidpointHandler(), new BlankCharProvider('_'));

var diamond = service.CreateDiamond(midpoint);

Console.WriteLine(diamond);
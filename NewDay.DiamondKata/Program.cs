if (args.Length == 0)
{
    Console.WriteLine($"{nameof(args)} cannot be empty");
    return;
}

var midpoint = args[0][0];

Console.WriteLine(midpoint);
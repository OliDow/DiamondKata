using KataDiamond;

if (args.Length == 1)
{
    var diamondFactory = new DiamondService();
    var letter = char.Parse(args[0]); // add error logging

    var items = diamondFactory.Generate(letter);
    diamondFactory.PrintDiamond(items);
}
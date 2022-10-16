using KataDiamond;

if (args.Length == 1)
{
    var diamondService = new DiamondService();
    var letter = char.Parse(args[0]); // add error logging

    var items = diamondService.Generate(letter);
    diamondService.PrintDiamond(items);
}
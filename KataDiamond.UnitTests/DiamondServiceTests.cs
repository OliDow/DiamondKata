namespace KataDiamond.UnitTests;

public class DiamondServiceTests
{
    private readonly DiamondService _diamondService = new();

    [Fact]
    public void GivenEnteredA_ShouldGenerateDiamondCorrectly()
    {
        // arrange
        const char letter = 'A';
        var expectedList = new List<string>
        {
            letter.ToString()
        }.ToArray();

        // act
        var actualList = _diamondService.Generate(letter);

        // assert
        expectedList.ShouldBeEquivalentTo(actualList);
    }

    [Fact]
    public void GivenEnteredB_ShouldGenerateDiamondCorrectly()
    {
        // arrange
        const char letter = 'B';
        var expectedList = new List<string>
        {
            " A ",
            "B B",
            " A ",
        }.ToArray();

        // act
        var actualList = _diamondService.Generate(letter);

        // assert
        expectedList.ShouldBeEquivalentTo(actualList);
    }

    [Fact]
    public void GivenEnteredC_ShouldGenerateDiamondCorrectly()
    {
        // arrange
        const char letter = 'C';
        var expectedList = new List<string>
        {
            "  A  ",
            " B B ",
            "C   C",
            " B B ",
            "  A  ",
        }.ToArray();

        // act
        var actualList = _diamondService.Generate(letter);

        // assert
        expectedList.ShouldBeEquivalentTo(actualList);
    }

    [Theory]
    [InlineData('Z')]
    [InlineData('G')]
    [InlineData('T')]
    public void GivenEnteredLetter_CenterRowShouldContainLetter(char letter)
    {
        // arrange
        var letterPosition = char.ToUpper(letter) - 64;
        var expectedPosition = letterPosition - 1; // Minus 1 as array is zero based

        // act
        var response = _diamondService.Generate(letter);

        // assert
        response[expectedPosition].ShouldContain(letter);
    }
}
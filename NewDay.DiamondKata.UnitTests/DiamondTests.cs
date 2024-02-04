using AutoFixture;
using FluentAssertions;
using NewDay.DiamondKata.Core;
using Xunit;

namespace NewDay.DiamondKata.UnitTests;

public class DiamondTests
{
    private readonly Fixture _fixture;

    public DiamondTests()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public void GivenSingleMidpoint_ReturnsDiamond()
    {
        // arrange
        var midpoint = 'A';
        var blankChar = _fixture.Create<char>();
        var diamond = new Diamond(new[] { midpoint }, blankChar);

        // act 
        var result = diamond.ToString();

        // assert
        result.Should().Be("A");
    }

    [Fact]
    public void GivenTwoMidpoints_ReturnsThreeLines()
    {
        // arrange
        var perimeter = new[] { 'A', 'B' };
        var blankChar = _fixture.Create<char>();
        var diamond = new Diamond(perimeter, blankChar);

        // act 
        var result = diamond.ToString();

        // assert
        result.Split(Environment.NewLine).Should().HaveCount(3);
    }

    [Fact]
    public void GivenTwoMidpoints_AddsBlankCharToLines()
    {
        // arrange
        var perimeter = _fixture.CreateMany<char>(2).ToArray();
        var blankChar = ' ';
        var diamond = new Diamond(perimeter, blankChar);

        // act 
        var result = diamond.ToString();

        // assert
        result.Split(Environment.NewLine).Should().OnlyContain(x=>x.Length == 3 && x.Contains(" "));
    }

    [Fact]
    public void GivenTwoMidpoints_CreatesDiamond()
    {
        // arrange
        var perimeter = new[] { 'A', 'A' };
        var blankChar = ' ';
        var diamond = new Diamond(perimeter, blankChar);

        // act 
        var result = diamond.ToString();

        // assert
        result.Split(Environment.NewLine)[0].Should().Be(" A ");
        result.Split(Environment.NewLine)[1].Should().Be("A A");
        result.Split(Environment.NewLine)[2].Should().Be(" A ");
    }

    [Fact]
    public void GivenDifferentMidpoints_CreatesDiamond()
    {
        // arrange
        var perimeter = new[] { 'A', 'B', 'C' };
        var blankChar = '_';
        var diamond = new Diamond(perimeter, blankChar);

        // act 
        var result = diamond.ToString();

        // assert
        result.Split(Environment.NewLine)[0].Should().Be("__A__");
        result.Split(Environment.NewLine)[1].Should().Be("_B_B_");
        result.Split(Environment.NewLine)[2].Should().Be("C___C");
        result.Split(Environment.NewLine)[3].Should().Be("_B_B_");
        result.Split(Environment.NewLine)[4].Should().Be("__A__");
    }
}
using FluentAssertions;
using Moq;
using NewDay.DiamondKata.Core;
using Xunit;

namespace NewDay.DiamondKata.UnitTests;

public class DiamondServiceTests
{
    [Fact]
    public void GivenAValidMidpoint_CorrectDiamondIsCreated()
    {
        // arrange
        var sut = new DiamondService(new MidpointHandler(), new BlankCharProvider('_'));

        // act
        var result = sut.CreateDiamond('C');

        // assert
        result.ToString().Split(Environment.NewLine)[0].Should().Be("__A__");
        result.ToString().Split(Environment.NewLine)[1].Should().Be("_B_B_");
        result.ToString().Split(Environment.NewLine)[2].Should().Be("C___C");
        result.ToString().Split(Environment.NewLine)[3].Should().Be("_B_B_");
        result.ToString().Split(Environment.NewLine)[4].Should().Be("__A__");
    }
}
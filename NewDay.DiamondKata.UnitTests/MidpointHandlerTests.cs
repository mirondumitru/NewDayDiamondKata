using FluentAssertions;
using NewDay.DiamondKata.Core;
using Xunit;

namespace NewDay.DiamondKata.UnitTests;

public class MidpointHandlerTests
{
    [Fact]
    public void GivenAValidInput_IsInRange_ReturnsTrue()
    {
        // act
        var isValid = new MidpointHandler().IsInRange('A');

        // assert
        isValid.Should().BeTrue();
    }

    [Fact]
    public void GivenAnInvalidInput_IsInRange_ReturnsFalse()
    {
        // act
        var isValid = new MidpointHandler().IsInRange('a');

        // assert
        isValid.Should().BeFalse();
    }

    [Fact]
    public void GivenTheEntireRangeOfValidInputs_IsInRange_ReturnsTrue()
    {
        // arrange
        var handler = new MidpointHandler();
        var range = Enumerable.Range(65, 26);

        // act & assert
        foreach (var item in range)
        {
            var isValid = handler.IsInRange((char)item);
            isValid.Should().BeTrue();
        }
    }

    [Fact]
    public void GivenAnyInputOutOfRange_IsInRange_ReturnsFalse()
    {
        // arrange
        var handler = new MidpointHandler();
        var range = Enumerable.Range(0, 65).Concat(Enumerable.Range(91, 165));

        // act & assert
        foreach (var item in range)
        {
            var isValid = handler.IsInRange((char)item);
            isValid.Should().BeFalse();
        }
    }

    [Fact]
    public void GivenAValidMidpoint_CreateRangeUpTo()
    {
        // arrange
        var handler = new MidpointHandler();

        // act
        var range = handler.CreateRangeUpTo('A');
        
        // assert
        range.Should().HaveCount(1);
        range.Should().Contain('A');
    }

    [Fact]
    public void GivenAnInvalidMidpoint_CreateRangeUpTo_ReturnsEmpty()
    {
        // arrange
        var handler = new MidpointHandler();

        // act
        var range = handler.CreateRangeUpTo('z');

        // assert
        range.Should().BeEmpty();
    }

    [Fact]
    public void GivenMultipleValidMidpoint_CreateRangeUpTo_ReturnsCorret()
    {
        // arrange
        var handler = new MidpointHandler();

        // act
        var range = handler.CreateRangeUpTo('C');

        // assert
        range.Should().ContainInConsecutiveOrder('A', 'B', 'C');
    }

    [Fact]
    public void GivenLastValidMidpoint_CreateRangeUpTo_ReturnEntireValidRange()
    {
        // arrange
        var handler = new MidpointHandler();

        // act
        var range = handler.CreateRangeUpTo('Z');

        // assert
        range.Should().HaveCount(26);
    }
}
using FluentAssertions;
using NewDay.DiamondKata.Core;
using Xunit;

namespace NewDay.DiamondKata.UnitTests;

public class MidpointValidatorTests
{
    [Fact]
    public void GivenAValidInput_ReturnsTrue()
    {
        // act
        var isValid = new MidpointValidator().IsValid('A');

        // assert
        isValid.Should().BeTrue();
    }

    [Fact]
    public void GivenAnInvalidInput_ReturnsFalse()
    {
        // act
        var isValid = new MidpointValidator().IsValid('a');

        // assert
        isValid.Should().BeFalse();
    }

    [Fact]
    public void GivenTheEntireRangeOfValidInputs_ReturnsTrue()
    {
        // arrange
        var validator = new MidpointValidator();
        var range = Enumerable.Range(65, 26);

        // act & assert
        foreach (var item in range)
        {
            var isValid = validator.IsValid((char)item);
            isValid.Should().BeTrue();
        }
    }

    [Fact]
    public void GivenAnyInputOutOfRange_ReturnsFalse()
    {
        // arrange
        var validator = new MidpointValidator();
        var range = Enumerable.Range(0, 65).Concat(Enumerable.Range(91, 165));

        // act & assert
        foreach (var item in range)
        {
            var isValid = validator.IsValid((char)item);
            isValid.Should().BeFalse();
        }
    }
}
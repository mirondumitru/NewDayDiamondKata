using AutoFixture;
using FluentAssertions;
using NewDay.DiamondKata.Core;
using Xunit;

namespace NewDay.DiamondKata.UnitTests;

public class BlankCharProviderTests
{
    [Fact]
    public void GivenAnyChar_ProviderReturnsItAsValue()
    {
        // arrange
        var fixture = new Fixture();
        var input = fixture.Create<char>();

        // act
        var result = new BlankCharProvider(input).Value;

        // assert
        result.Should().Be(input);
    }
}
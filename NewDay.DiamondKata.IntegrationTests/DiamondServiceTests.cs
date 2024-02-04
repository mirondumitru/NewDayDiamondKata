using AutoFixture;
using FluentAssertions;
using Moq;
using NewDay.DiamondKata.Core;
using Xunit;

namespace NewDay.DiamondKata.UnitTests;

public class DiamondServiceTests
{
    private readonly Fixture _fixture;
    private readonly MockRepository _mockRepository;
    private readonly Mock<IMidpointHandler> _mockMidpointHandler;

    public DiamondServiceTests()
    {
        _mockRepository = new MockRepository(MockBehavior.Strict);
        _mockMidpointHandler = _mockRepository.Create<IMidpointHandler>();
        _fixture = new Fixture();
    }

    [Fact]
    public void GivenAMidpoint_ItGetsValidated()
    {
        // arrange
        var sut = new DiamondService(_mockMidpointHandler.Object);

        _mockMidpointHandler.Setup(x => x.IsInRange(It.IsAny<char>())).Returns(true);
        _mockMidpointHandler.Setup(x => x.CreateRangeUpTo(It.IsAny<char>())).Returns(_fixture.CreateMany<char>().ToArray());

        // act
        sut.CreateDiamond(_fixture.Create<char>());

        // assert
        _mockMidpointHandler.Verify(x => x.IsInRange(It.IsAny<char>()), Times.Exactly(1));
    }

    [Fact]
    public void GivenAnInvalidMidpoint_CreateDiamond_ThrowsException()
    {
        // arrange
        var sut = new DiamondService(_mockMidpointHandler.Object);
        var midpoint = _fixture.Create<char>();

        _mockMidpointHandler.Setup(x => x.IsInRange(midpoint)).Returns(false);

        // act
        var action = () => sut.CreateDiamond(midpoint);

        // assert
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void GivenAValidMidpoint_RangeIsCreated()
    {
        // arrange
        var sut = new DiamondService(_mockMidpointHandler.Object);
        var midpoint = _fixture.Create<char>();
        _mockMidpointHandler.Setup(x => x.IsInRange(midpoint)).Returns(true);
        _mockMidpointHandler.Setup(x => x.CreateRangeUpTo(midpoint)).Returns(_fixture.CreateMany<char>().ToArray());

        // act
        sut.CreateDiamond(midpoint);

        // assert
        _mockMidpointHandler.Verify(x=>x.CreateRangeUpTo(midpoint), Times.Exactly(1));
    }

    [Fact]
    public void GivenAValidMidpoint_RangeIsUsedToCreateDiamond()
    {
        // arrange
        var sut = new DiamondService(_mockMidpointHandler.Object);
        var midpoint = _fixture.Create<char>();
        _mockMidpointHandler.Setup(x => x.IsInRange(midpoint)).Returns(true);
        _mockMidpointHandler.Setup(x => x.CreateRangeUpTo(midpoint)).Returns(_fixture.CreateMany<char>(2).ToArray());

        // act
        var result = sut.CreateDiamond(midpoint);

        // assert
        result.ToString().Split(Environment.NewLine).Should().HaveCount(3);
    }
}
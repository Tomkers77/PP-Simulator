using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallTorusMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        // Arrange
        int sizeX = 15;
        int sizeY = 18;

        // Act
        var map = new SmallTorusMap(sizeX, sizeY);
        // Assert
        Assert.Equal(sizeX, map.SizeX);
        Assert.Equal(sizeY, map.SizeY);
    }

    //-----------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(2, 10)]
    [InlineData(10, 51)]
    [InlineData(2, 2)]
    [InlineData(50, 50)]
    public void
        Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException
        (int sizeX, int sizeY)
    {
        // Act & Assert
        // The way to check if method throws anticipated exception:
        Assert.Throws<ArgumentOutOfRangeException>(() =>
             new SmallTorusMap(sizeX, sizeY));
    }

    //------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(3, 4, 15, 17, true)]
    [InlineData(19, 1, 15, 17, false)]
    [InlineData(-5, 10, 15, 17, false)]
    [InlineData(13, 20, 15, 17, false)]
    [InlineData(13, -6, 15, 17, false)]
    [InlineData(11, 13, 15, 17, true)]
    public void Exist_ShouldReturnCorrectValue(int x, int y,
        int sizeX, int sizeY, bool expected)
    {
        // Arrange
        var map = new SmallTorusMap(sizeX, sizeY);
        var point = new Point(x, y);
        // Act
        var result = map.Exist(point);
        // Assert
        Assert.Equal(expected, result);
    }

    //---------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(0, 0, Direction.Down, 0, 16)]
    [InlineData(0, 8, Direction.Left, 10, 8)]
    [InlineData(10, 10, Direction.Right, 0, 10)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallTorusMap(11,17);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.Next(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    //-------------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(4, 10, Direction.Up, 5, 11)]
    [InlineData(0, 0, Direction.Down, 5, 17)]
    [InlineData(0, 8, Direction.Left, 5, 9)]
    [InlineData(5, 10, Direction.Right, 0, 9)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallTorusMap(6,18);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.NextDiagonal(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}

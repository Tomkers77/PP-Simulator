using Simulator.Maps;
using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        int sizeX = 15;
        int sizeY = 18;
        var map = new SmallSquareMap(sizeX, sizeY);
        Assert.Equal(sizeX, map.SizeX);
        Assert.Equal(sizeY, map.SizeY);
    }

    //------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(2, 10)]
    [InlineData(10, 51)]
    [InlineData(2, 2)]
    [InlineData(50,50)]
       public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int sizeX, int sizeY)
    {
        
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(sizeX, sizeY));
    }
    
    //----------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(1, 2, 5, 7, true)]
    [InlineData(6, 5, 5, 7, false)]
    [InlineData(-2, 3, 5, 7, false)]
    [InlineData(2, 8, 5, 7, false)]
    [InlineData(2, -5, 5, 7, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int sizeX, int sizeY, bool expected)
    {
        var map = new SmallSquareMap(sizeX, sizeY);
        var point = new Point(x, y);
        var result = map.Exist(point);
        Assert.Equal(expected, result);
    }

    //------------------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(3, 2, Direction.Up, 3, 3)]
    [InlineData(3, 0, Direction.Down, 3, 0)]
    [InlineData(0, 5, Direction.Left, 0, 5)]
    [InlineData(4, 6, Direction.Right, 4, 6)]
    [InlineData(2, 6, Direction.Up, 2, 6)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(5,7);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    //----------------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(3, 5, Direction.Up, 4, 6)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(0, 3, Direction.Left, 0, 3)]
    [InlineData(4, 6, Direction.Right, 4, 6)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(5, 7);
        var point = new Point(x, y);
        var nextPoint = map.NextDiagonal(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}

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
        int size = 15;
        var map = new SmallSquareMap(size);
        Assert.Equal(size, map.Size);
    }

    //------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(2)]
    [InlineData(51)]
       public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
    {
        
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }
    
    //----------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(1, 2, 5, true)]
    [InlineData(16, 5, 10, false)]
    [InlineData(19, 19, 20, true)]
    [InlineData(20, 20, 20, false)]
    [InlineData(0, 0, 20, true)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int size, bool expected)
    {
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);
        var result = map.Exist(point);
        Assert.Equal(expected, result);
    }

    //------------------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(3, 0, Direction.Down, 3, 0)]
    [InlineData(0, 8, Direction.Left, 0, 8)]
    [InlineData(11, 10, Direction.Right, 11, 10)]
    [InlineData(7, 11, Direction.Up, 7, 11)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(12);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    //----------------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(0, 8, Direction.Left, 0, 8)]
    [InlineData(11, 10, Direction.Right, 11, 10)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(12);
        var point = new Point(x, y);
        var nextPoint = map.NextDiagonal(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}

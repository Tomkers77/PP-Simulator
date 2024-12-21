using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class PointTests
{
    [Theory]
    [InlineData(0, 0, "(0, 0)")]
    [InlineData(5, 10, "(5, 10)")]
    [InlineData(-3, -7, "(-3, -7)")]
    public void ToString_ShouldReturnFormattedString(int x, int y, string expected)
    {
        Point point = new Point(x, y);
        var result = point.ToString();
        Assert.Equal(expected, result);
    }

    //------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(4, 5, Direction.Up, 4, 6)]
    [InlineData(4, 5, Direction.Down, 4, 4)]
    [InlineData(4, 5, Direction.Right, 5, 5)]
    [InlineData(4, 5, Direction.Left, 3, 5)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        Point testPoint = new Point(x, y);
        Point nextTestPoint = testPoint.Next(direction);
        Point expectedPoint = new Point(expectedX, expectedY);
        Assert.Equal(expectedPoint, nextTestPoint);
    }

    //-------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(4, 5, Direction.Up, 5, 6)]
    [InlineData(4, 5, Direction.Down, 3, 4)]
    [InlineData(4, 5, Direction.Right, 5, 4)]
    [InlineData(4, 5, Direction.Left, 3, 6)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        Point testPoint = new Point(x, y);
        Point nextTestPoint = testPoint.NextDiagonal(direction);
        Point expectedPoint = new Point(expectedX, expectedY);
        Assert.Equal(expectedPoint, nextTestPoint);
    }

}

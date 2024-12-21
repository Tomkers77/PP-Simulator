using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class RectangleTests
{
    [Theory]
    [InlineData(2,5,2,1)]
    [InlineData(51,6,51,6)]
    public void Constructor_SameParametrs_ShouldThrowArgumentException(int x1, int y1, int x2, int y2)
    {

        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }

    //-------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(2, 5, 46, 1, "(2, 1):(46, 5)")]
    [InlineData(5, 61, 51, 6, "(5, 6):(51, 61)")]
    [InlineData(55, 61, 51, 6, "(51, 6):(55, 61)")]
    public void Constructor_DiffrentOrderParametrs_ShouldBeReplaced(int x1, int y1, int x2, int y2, string expectedRect)
    {
        Rectangle exRecTest = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(exRecTest.ToString(), expectedRect);
    }

    //---------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData(3, 5, 6, 10, 4, 7, true)]  
    [InlineData(3, 5, 6, 10, 3, 7, true)]  
    [InlineData(3, 5, 6, 10, 6, 7, true)]  
    [InlineData(3, 5, 6, 10, 7, 7, false)] 
    [InlineData(3, 5, 6, 10, 5, 11, false)] 
    [InlineData(3, 5, 6, 10, 6, 2, false)]
    public void Contains_ShouldReturnCorrectResult(int x1, int y1, int x2, int y2, int px, int py, bool expected)
    {
        // Arrange
        Rectangle rectangle = new Rectangle(x1, y1, x2, y2);
        Point point = new Point(px, py);

        // Act
        bool result = rectangle.Contains(point);

        // Assert
        Assert.Equal(expected, result);
    }


}

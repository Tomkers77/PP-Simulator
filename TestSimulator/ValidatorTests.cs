using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(0, 1, 10, 1)]
    [InlineData(15, 1, 10, 10)]
    [InlineData(1, 1, 10, 1)]
    [InlineData(10, 1, 10, 10)]
    public void Limiter_ShouldReturnClampedValue(int value, int min, int max, int expected)
    {      
        var result = Validator.Limiter(value, min, max);

        Assert.Equal(expected, result);
    }

    //-----------------------------------------------------------------------------------------------------------

    [Theory]
    [InlineData("abcde", 5, 10, '#', "Abcde")]          
    [InlineData("za dluga nazwa", 5, 10, '#', "Za dluga n")] 
    [InlineData("krotka", 10, 15, '#', "Krotka####")]        
    [InlineData("a", 5, 10, '#', "A####")]                 
    [InlineData("    wyraz    ", 5, 10, '#', "Wyraz")]
    [InlineData("", 5, 10, '#', "#####")]
    public void Shortener_ShouldReturnFormattedString(string input, int min, int max, char placeholder, string expected)
    {
        // Act
        var result = Validator.Shortener(input, min, max, placeholder);

        // Assert
        Assert.Equal(expected, result);
    } 
}

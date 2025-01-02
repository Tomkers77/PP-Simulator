using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string letters)
    {
        List<Direction> route = new();
        letters = letters.ToLower();
        foreach (char letter in letters)
        {   
            switch (letter)
            {
                case 'u':
                    route.Add(Direction.Up);
                    break;
                case 'r':
                    route.Add(Direction.Right);
                    break;
                case 'd':
                    route.Add(Direction.Down);
                    break;
                case 'l':
                    route.Add(Direction.Left);
                    break;
                default:
                    continue;
            }
        }
        return route;
    }
}
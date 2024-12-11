using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string letters)
    {
        string route = "";
        letters = letters.ToLower();
        foreach (char letter in letters)
        {
            if (letter == 'u' || letter == 'r' || letter == 'd' || letter == 'l')
            {
                route += letter;
            }
        }
        Direction[] Travel = new Direction[route.Length];

        for (int i = 0; i < route.Length; i++)
        {
            switch (route[i])
            {
                case 'u':
                    Travel[i] = Direction.Up;
                    break;
                case 'r':
                    Travel[i] = Direction.Right;
                    break;
                case 'd':
                    Travel[i] = Direction.Down;
                    break;
                case 'l':
                    Travel[i] = Direction.Left;
                    break;
                default:
                    continue;
            }
        }
        return Travel;
    }
}
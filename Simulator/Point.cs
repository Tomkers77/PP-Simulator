﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public readonly struct Point
{
    public readonly int X, Y;
    public Point(int x, int y) => (X, Y) = (x, y);
    public override string ToString() => $"({X}, {Y})";

    public Point Next(Direction direction)
    {
        if (direction == Direction.Left) return new Point(X - 1, Y);
        else if (direction == Direction.Right) return new Point(X + 1, Y);
        else if(direction == Direction.Up) return new Point(X, Y + 1);
        else return new Point(X, Y - 1);
    }

    // rotate given direction 45 degrees clockwise
    public Point NextDiagonal(Direction direction)
    {
        if (direction == Direction.Left) return new Point(X - 1, Y + 1);
        else if (direction == Direction.Right) return new Point(X +1, Y - 1);
        else if (direction == Direction.Up) return new Point(X + 1, Y + 1);
        else return new Point(X - 1, Y - 1);
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public interface IMappable
{
    Point Position { get; set; }

    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point point);
}

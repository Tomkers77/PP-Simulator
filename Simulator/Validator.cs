﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max) 
    {
        if (value < min)
        {
            value = min;
        }
        if (value > max)
        {
            value = max;
        }
        return value;
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    { 
        value = value.Trim();

        if (value.Length > max)
        {
            value = value.Remove(max).TrimEnd();
        }

        if (value.Length < min)
        {
            value = value.PadRight(min, placeholder);
        }

        if (char.IsLower(value[0]))
        {
            value = char.ToUpper(value[0]) + value.Substring(1);
        }
        return value;

    }
}

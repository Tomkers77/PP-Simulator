﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public abstract class Creature
{
    private string _name = "Unknown";
    public string Name
    {
        get { return _name; }
        init
        {
            _name = Validator.Shortener(value, 3, 25, '#');
        }
    }

    private int _level = 1;
    public int Level 
    { 
        get { return _level; }
        init
        {
            _level = Validator.Limiter(value, 1, 10);
        } 
    }

    public abstract int Power { get; }

    //--------------------------------------------------
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    //---------------------------------------------------
    public abstract string Greeting();


    public abstract string Info {  get; }
    

    public void Upgrade() 
    { 
        if (Level < 10)
        {
            _level++;
        }
    }

    //----------------------------------------------------

    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    public string[] Go(Direction[] motions)
    {
        string[] result = new string[motions.Length];


        for (int i = 0; i< motions.Length; i++)
        {
            result[i] = $"{Name} goes {Go(motions[i])}";
        }
        return result;
    }

    public string[] Go(string travel)
    {
        List<Direction> directions = DirectionParser.Parse(travel);
        return Go(directions.ToArray());
    }

    //------------------------------------------------------------------------

    public override string ToString()
    {
        return GetType().Name.ToUpper() + ": " + Info;
    }
}

   

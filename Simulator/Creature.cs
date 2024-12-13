using System;
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
    public abstract void SayHi();


    public abstract string Info {  get; }
    

    public void Upgrade() 
    { 
        if (Level < 10)
        {
            _level++;
        }
    }

    //----------------------------------------------------

    public void Go(Direction transfer)
    {
        string move = transfer.ToString();
        move = char.ToLower(move[0]) + move.Substring(1);
        Console.WriteLine($"{Name} goes {move}");
    }

    public void Go(Direction[] motions)
    {
        foreach (Direction motion in motions)
        {
            Go(motion);
        }
    }

    public void Go(string travel)
    {
        Go(DirectionParser.Parse(travel));
    }

    //------------------------------------------------------------------------

    public override string ToString()
    {
        return GetType().Name.ToUpper() + ": " + Info;
    }
}

   

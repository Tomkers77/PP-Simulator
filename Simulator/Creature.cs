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

internal class Creature
{
    private string _name = "Unknown";
    public string Name
    {
        get { return _name; }
        init
        {
            
            string name = value.Trim();
            
            if (name.Length > 25)
            {
                name = name.Remove(25).TrimEnd();
            }

            if (name.Length < 3) 
            {
                name = name.PadRight(3, '#');
            }

            if (char.IsLower(name[0]))
            {
                name = char.ToUpper(name[0]) + name.Substring(1);
            }
            
            _name = name;
        }
    }

    private int _level = 1;
    public int Level 
    { 
        get { return _level; }
        init
        {
            int level = value;
            if (level < 1)
            {
                level = 1;
            }
            if (level > 10)
            {
                level = 10;
            }

             _level = level;
        } 
    }

    //--------------------------------------------------
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    //---------------------------------------------------
    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }

    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }

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

}

   

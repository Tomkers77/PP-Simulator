using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Elf : Creature
{
    private int _agility;
    public int Agility
    {
        get { return _agility; }
        init
        {
            int agility = value;
            if (agility > 10) { agility = 10; }
            if (agility < 0) { agility = 0; }
            _agility = agility;
        }
    }

    private int singCount = 0;
    public void Sing()
    {
        singCount++;
        Console.WriteLine($"{Name} is singing.");
        if (_agility < 10) { 
            if (singCount % 3 == 0)
            {
                _agility++;
            }
        }
    }

    //---------------------------------------------------------------------------------

    public Elf() :base() { }
    
    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    //---------------------------------------------------------------------------------

    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");

    public override int Power => 8 * Level + 2 * _agility;
}

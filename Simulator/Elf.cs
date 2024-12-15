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
            _agility = Validator.Limiter(value, 0, 10);
        }
    }

    private int singCount = 0;
    public void Sing()
    {
        singCount++;
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

    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";

    public override int Power => 8 * Level + 2 * Agility;

    public override string Info => $"{Name} [{Level}][{Agility}]"; 
    
}

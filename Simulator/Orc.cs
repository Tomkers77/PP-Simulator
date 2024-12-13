using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Orc : Creature
{
    private int _rage;
    public int Rage 
    {
        get { return _rage; }
        init
        {
            int rage = value;
            if (rage > 10) { rage = 10; }
            if (rage < 0) { rage = 0; }
            _rage = rage;
        }
    }

    private int huntCount = 0;
    public void Hunt()
    {
        huntCount++;
        Console.WriteLine($"{Name} is hunting.");
        if (_rage < 10)
        {
            if (huntCount % 2 == 0)
            {
                _rage++;
            }
        }
    }

    //----------------------------------------------------------------------------------

    public Orc() : base() { }
    

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    //-----------------------------------------------------------------------------------

    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");

    public override int Power => 7 * Level + 3 * _rage;
}

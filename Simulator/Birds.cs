using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Birds : Animals
{
    public bool CanFly {  get; set; } = true;

    public override char Symbol => CanFly ? 'B' : 'b';

    public override string Info
    {
        get
        {
            string skill = "";
            if (CanFly == true)
            {
                skill = "(fly+)";
            }
            else
            {
                skill = "(fly-)";
            }
            return $"{Description} {skill} <{Size}>";
        }
    }

    public override void Go(Simulator.Direction direction)
    {
        if (CanFly == true)
        {
            for (int i = 0; i < 2; i++)
            {
                Point nextPoint = Map.Next(Position, direction);
                Map.Move(this, nextPoint);
            }
        }
        else 
        {
            Point nextPoint = Map.NextDiagonal(Position, direction); 
            Map.Move(this, nextPoint);
        }
    }
}

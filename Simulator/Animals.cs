using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Animals: IMappable
{
    public virtual char Symbol => 'A';

    private string _description = "No Data";
    public required string Description 
    { 
        get { return _description; }
        init
        {
            _description = Validator.Shortener(value, 3, 15, '#');
        } 
    }
    public uint Size { get; set; } = 3;

    public virtual string Info
    {
        get
        {
            return $"{Description} <{Size}>";
        }

    }

    public Point Position { get; set; }

    public Map? Map { get; set; }


    //----------------------------------------------------------------------------------

    public override string ToString()
    {
        return GetType().Name.ToUpper() + ": " + Info;
    }

    public virtual void Go(Direction direction)
    {
        if (Map == null)
        {
            throw new InvalidOperationException("Creature nie ma mapy!");

        }
        else
        {
            Point nextPoint = Map.Next(Position, direction);
            Map.Move(this, nextPoint);
        }
    }

    public virtual void InitMapAndPosition(Map map, Point position)
    {
        Map = map;
        map.Add(this, position);
    }
}

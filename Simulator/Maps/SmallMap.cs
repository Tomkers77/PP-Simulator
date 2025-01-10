using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private List<Creature>[,] _fields;
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX));
        }
        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY));
        }    

        _fields = new List<Creature>[SizeX, SizeY];
    }

    public override bool Exist(Point p)
    {
        Rectangle exRec = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
        bool check = exRec.Contains(p);
        return check;
    }

    public override void Add(Creature creature, Point point)
    {
        if (!Exist(point))
        {
            throw new ArgumentOutOfRangeException(nameof(point));
        }

        List<Creature> creaturesAtPoint = At(point);

        if (creaturesAtPoint.Contains(creature))
        {
            throw new InvalidOperationException("Creature juz istnieje w tym punkcie)");
        }
        else
        {
            _fields[point.X, point.Y].Add(creature);
            creature.Position = point;
        }
    }

    public override void Remove(Creature creature, Point point)
    {
        if (!Exist(point))
        {
            throw new ArgumentOutOfRangeException(nameof(point));
        }

        List<Creature> creaturesAtPoint = At(point);

        if (creaturesAtPoint.Contains(creature))
        {
            _fields[point.X,point.Y].Remove(creature);
        }
        else
        {
            throw new InvalidOperationException("Tego Creature nie ma w tym punkcie");
        }
    }

    public override void Move(Creature creature, Point point)
    {
        if (!Exist(point))
        {
            throw new ArgumentOutOfRangeException(nameof(point));
        }
        else
        {
            Remove(creature,creature.Position);
            Add(creature, point);
        }
    }

    public override List<Creature> At(Point point)
    {
        if (!Exist(point))
        {
            return new List<Creature>();
        }

        return _fields[point.X, point.Y];
    }

    public override List<Creature> At(int x, int y)
    {
        Point pointTemp = new Point(x,y);

        return At(pointTemp);
    }

}

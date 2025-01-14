using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private List<IMappable>[,] _fields;
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

        _fields = new List<IMappable>[SizeX, SizeY];

        for (int i = 0; i < SizeX; i++)
        {
            for (int j = 0; j < SizeY; j++)
            {
                _fields[i, j] = new List<IMappable>();
            }
        }
    }

    public override bool Exist(Point p)
    {
        Rectangle exRec = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
        bool check = exRec.Contains(p);
        return check;
    }

    public override void Add(IMappable creature, Point point)
    {
        if (!Exist(point))
        {
            throw new ArgumentOutOfRangeException(nameof(point));
        }

        List<IMappable> creaturesAtPoint = At(point);

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

    public override void Remove(IMappable creature, Point point)
    {
        if (!Exist(point))
        {
            throw new ArgumentOutOfRangeException(nameof(point));
        }

        List<IMappable> creaturesAtPoint = At(point);

        if (creaturesAtPoint.Contains(creature))
        {
            _fields[point.X,point.Y].Remove(creature);
        }
        else
        {
            throw new InvalidOperationException("Tego Creature nie ma w tym punkcie");
        }
    }

    public override void Move(IMappable creature, Point point)
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

    public override List<IMappable> At(Point point)
    {
        if (!Exist(point))
        {
            return new List<IMappable>();
        }

        return _fields[point.X, point.Y];
    }

    public override List<IMappable> At(int x, int y)
    {
        Point pointTemp = new Point(x,y);

        return At(pointTemp);
    }

}

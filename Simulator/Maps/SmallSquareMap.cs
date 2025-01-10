using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{

    public SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }


    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = new Point();
        nextPoint = p.Next(d);
        return Exist(nextPoint) == true ? nextPoint : p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextDiagPoint = new Point();
        nextDiagPoint = p.NextDiagonal(d);
        return Exist(nextDiagPoint) == true ? nextDiagPoint : p;
    }
}

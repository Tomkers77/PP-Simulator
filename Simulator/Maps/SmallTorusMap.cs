using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    //----------------------------------------------------------------------

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = new Point();
        nextPoint = p.Next(d);

        int newNextPointX = (nextPoint.X + SizeX) % SizeX;
        int newNextPointY = (nextPoint.Y + SizeY) % SizeY;

        Point newNextPoint = new Point(newNextPointX, newNextPointY);
        return newNextPoint;
    }
    

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = new Point();
        nextPoint = p.NextDiagonal(d);

        int newNextPointX = (nextPoint.X + SizeX) % SizeX;
        int newNextPointY = (nextPoint.Y + SizeY) % SizeY;

        Point newNextPoint = new Point(newNextPointX, newNextPointY);
        return newNextPoint;
    }
}

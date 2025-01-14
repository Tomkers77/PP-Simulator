using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int SizeX { get; set; }
    public int SizeY { get; set; }

    public abstract void Add(IMappable c, Point p);

    public abstract void Remove(IMappable c, Point p);

    public abstract void Move(IMappable c, Point p);

    public abstract List<IMappable> At(Point p);

    public abstract List<IMappable> At(int x, int y);
    

    public Map(int sizeX, int sizeY)
    {
        if (sizeX >= 5 && sizeY >= 5)
        {
            SizeX = sizeX;
            SizeY = sizeY;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Podano niewłaściwy rozmiar. Podaj liczbę z zakresu <5,20>");
        }
    }


    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public abstract bool Exist(Point p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallSquareMap : Map
    {
        public int Size { get; }

        public SmallSquareMap(int size) 
        {
            if (size >= 5 && size <= 20)
            {
                Size = size;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Podano niewłaściwy rozmiar. Podaj liczbę z zakresu <5,20>");
            }
        }

        public override bool Exist(Point p)
        {
            Rectangle exRec = new Rectangle(0, 0, Size - 1, Size - 1);
            bool check = exRec.Contains(p);
            return check;
        }

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
}

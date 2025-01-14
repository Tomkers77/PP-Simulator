using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    private Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Console.Clear();
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write(Box.TopLeft);
        for (int i = 0; i < _map.SizeX - 1; i++)
        {
            Console.Write(new string(Box.Horizontal, 3));
            Console.Write(Box.TopMid);
        }
        Console.WriteLine(new string(Box.Horizontal, 3) + Box.TopRight);


        for (int j = 0; j < _map.SizeY - 1; j++)
        {
            Console.Write(Box.Vertical);
            for (int i = 0; i < _map.SizeX; i++)
            {

                var creatures = _map.At(i, j);
                if (creatures.Count == 1)
                {
                    if (creatures[0] is Orc)
                    {
                        Console.Write(" O ");
                    }
                    else if (creatures[0] is Elf)
                    {
                        Console.Write(" E ");
                    }    
                }
                else if (creatures.Count > 1)
                {
                    Console.Write(" X ");
                }
                else
                {
                    Console.Write("   ");
                }

                if (i < _map.SizeX - 1)
                    Console.Write(Box.Vertical);
            }
            Console.WriteLine(Box.Vertical);


            Console.Write(Box.MidLeft);
            for (int i = 0; i < _map.SizeX - 1; i++)
            {
                Console.Write(new string(Box.Horizontal, 3));
                Console.Write(Box.Cross);
            }
            Console.WriteLine(new string(Box.Horizontal, 3) + Box.MidRight);
        }


        Console.Write(Box.Vertical);
        for (int i = 0; i < _map.SizeX; i++)
        {
            var creatures = _map.At(i, _map.SizeY - 1);
            if (creatures.Count == 1)
            {
                if (creatures[0] is Orc)
                {
                    Console.Write(" O ");
                }
                else if (creatures[0] is Elf)
                {
                    Console.Write(" E ");
                }
            }
            else if (creatures.Count > 1)
            {
                Console.Write(" X ");
            }
            else
            {
                Console.Write("   ");
            }
            if (i < _map.SizeX - 1)
                Console.Write(Box.Vertical);
        }
        Console.WriteLine(Box.Vertical);

        Console.Write(Box.BottomLeft);
        for (int i = 0; i < _map.SizeX - 1; i++)
        {
            Console.Write(new string(Box.Horizontal, 3));
            Console.Write(Box.BottomMid);
        }
        Console.WriteLine(new string(Box.Horizontal, 3) + Box.BottomRight);
    }

}

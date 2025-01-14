using Simulator;
using Simulator.Maps;
using System.Text;
using System;
using SimConsole;

namespace Runner;

public class Program
{
    static void Main(string[] args)
    {
        /* Console.WriteLine("Starting Simulator!\n");


         Lab4a();

         Console.WriteLine();
         Console.WriteLine();

         Creature c = new Elf("Elandor", 5, 3);
         Console.WriteLine(c);  // ELF: Elandor [5]

         Console.WriteLine();
         Console.WriteLine();

         Lab4b();

         Point p = new(10, 25);
         Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
         Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)

         Console.WriteLine();
         Console.WriteLine();

         Lab5a();
        
         Lab5b();
        

        var map = new SmallTorusMap(10, 10);
        var creatures = new List<Creature> { new Orc("Orc1"), new Elf("Elf1") };
        var positions = new List<Point> { new Point(0, 3), new Point(2, 5) };
        var moves = "rngeuslwu";

        var simulation = new Simulation(map, creatures, positions, moves);

        while (!simulation.Finished)
        {
            simulation.Turn();
            //Console.WriteLine($"Ruch wykonany: {simulation.CurrentCreature.Name} w kierunku {simulation.CurrentMoveName}");
        }
        */

        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5, 5);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(0, 3), new(2, 3)];
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);
        mapVisualizer.Draw();


    }
    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.Greeting();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.Greeting();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.Greeting();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.Greeting();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
    o,
    e,
    new Orc("Morgash", 3, 8),
    new Elf("Elandor", 5, 3)
    };

        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }

    static void Lab4b()
    {
        object[] myObjects = {
    new Animals() { Description = "dogs"},
    new Birds { Description = "  eagles ", Size = 10 },
    new Elf("e", 15, -3),
    new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        Console.WriteLine();
    }

    static void Lab5a()
    {
        Rectangle exRec1 = new Rectangle(1, 2, 3, 4);
        Console.WriteLine($"Współrzędne punktów przy danych kolejno (1, 2, 3, 4): {exRec1.ToString()}");

        Rectangle exRec2 = new Rectangle(8, 7, 6, 5);
        Console.WriteLine($"Współrzędne punktów przy danych kolejno (8, 7, 6, 5): {exRec2.ToString()}");

        Console.WriteLine();

        Point exPoint1 = new Point(2, 3);
        Console.WriteLine($"Czy punkt {exPoint1} należy do pierwszego prostokąta: {exRec1.Contains(exPoint1)}");
        Console.WriteLine($"Czy punkt {exPoint1} należy do drugiego prostokąta: {exRec2.Contains(exPoint1)}");

        Console.WriteLine();

        try
        {
            Console.WriteLine("Próba utworzenia chudego prostokąta dla osi X");
            Console.Write("Efekt: ");
            Rectangle exRec3 = new Rectangle(1, 2, 1, 5);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();

        try
        {
            Console.WriteLine("Próba utworzenia chudego prostokąta dla osi Y");
            Console.Write("Efekt: ");
            Rectangle exRec3 = new Rectangle(1, 2, 11, 2);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
    }

    public static void Lab5b()
    {
        SmallSquareMap exMap1 = new SmallSquareMap(12, 35);

        Point p1 = new Point(1, 5);
        Point p2 = new Point(12, 12);
        Point p3 = new Point(11, 11);
        Point p4 = new Point(63, 35);

        Console.WriteLine(exMap1.Exist(p1));
        Console.WriteLine(exMap1.Exist(p2));
        Console.WriteLine(exMap1.Exist(p3));
        Console.WriteLine(exMap1.Exist(p4));

        Console.WriteLine();

        Console.WriteLine($"{p1}, w góre {exMap1.Next(p1, Direction.Up)}");
        Console.WriteLine($"{p2}, w dół {exMap1.Next(p2, Direction.Down)}");
        Console.WriteLine($"{p3}, w lewo {exMap1.Next(p3, Direction.Left)}");
        Console.WriteLine($"{p4}, w prawo {exMap1.Next(p4, Direction.Right)}");

        Console.WriteLine();

        Console.WriteLine($"{p1}, w góre i w prawo {exMap1.NextDiagonal(p1, Direction.Up)}");
        Console.WriteLine($"{p2}, w dół i w lewo {exMap1.NextDiagonal(p2, Direction.Down)}");
        Console.WriteLine($"{p3}, w lewo i w góre {exMap1.NextDiagonal(p3, Direction.Left)}");
        Console.WriteLine($"{p4}, w prawo i w dół {exMap1.NextDiagonal(p4, Direction.Right)}");


        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        try
        {
            SmallSquareMap exMap2 = new SmallSquareMap(22,35);

        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.ParamName);
        }
    }
    
}

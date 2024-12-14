namespace Simulator;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        /*
        Lab4a();

        Console.WriteLine();
        Console.WriteLine();

        Creature c = new Elf("Elandor", 5, 3);
        Console.WriteLine(c);  // ELF: Elandor [5]

        Console.WriteLine();
        Console.WriteLine();

       // Lab4b();

        Point p = new(10, 25);
        Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
        Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)
        */

        Lab5a();
    }

    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
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
    }

    static void Lab5a()
    {
        Rectangle exRec1 = new Rectangle(1, 2, 3, 4);
        Console.WriteLine(exRec1.ToString());

        Rectangle exRec2 = new Rectangle(8, 7, 6, 5);
        Console.WriteLine(exRec2.ToString());

        Point exPoint1 = new Point(2, 3);
        Console.WriteLine(exRec1.Contains(exPoint1));
        Console.WriteLine(exRec2.Contains(exPoint1));

        try
        {
            Rectangle exRec3 = new Rectangle(1, 2, 1, 5);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            Rectangle exRec3 = new Rectangle(1, 2, 11, 2);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

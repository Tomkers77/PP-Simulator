using Simulator.Maps;
using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole;

public class Program
{
    static void Main(string[] args) 
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallTorusMap map = new(8, 6);
        List<IMappable> creatures = [
            new Orc("Gorbag"), 
            new Elf("Elandor"), 
            new Animals { Description = "Kroliki", Size = 4 }, 
            new Birds { Description = "Orly", Size = 2, CanFly = true },
            new Birds { Description = "Strusie", Size = 3, CanFly = false }];
        List<Point> points = [new(0, 3), new(2, 3), new(0, 1), new(3, 3), new(1, 4)];
        string moves = "durld";

        
        Simulation simulation = new(map, creatures, points, moves);
        //SimulationHistory history = new(simulation);
        MapVisualizer mapVisualizer = new(simulation.Map);
        mapVisualizer.Draw();
    }

}

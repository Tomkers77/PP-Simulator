using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Simulator;
using Simulator.Maps;

public class IndexModel : PageModel
{
    private Simulation _simulation;
    private SimulationHistory _history;
    public int Counter { get; private set; }
    public SimulationTurnLog CurrentLog { get; private set; }
    public int MapSizeX => _simulation.Map.SizeX;
    public int MapSizeY => _simulation.Map.SizeY;

    public void Setup()
    {
        SmallTorusMap map = new(8, 6);
        List<IMappable> creatures = [
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals { Description = "Kroliki", Size = 4 },
            new Birds { Description = "Orly", Size = 2, CanFly = true },
            new Birds { Description = "Strusie", Size = 3, CanFly = false }];
        List<Point> points = [new(0, 3), new(2, 3), new(0, 1), new(3, 3), new(1, 4)];
        string moves = "durl";

        _simulation = new(map, creatures, points, moves);
        _history = new SimulationHistory(_simulation);
        CurrentLog = _history.TurnLogs[Counter];
    }

    public void OnGet()
    {
        Counter = HttpContext.Session.GetInt32("Counter") ?? 0;
        if (_simulation == null)
        {
            Setup();
        }
    }

    public void OnPost(string action)
    {
        Counter = HttpContext.Session.GetInt32("Counter") ?? 0;
        if (_history == null)
        {
            Setup();
        }
        if (action == "next")
        {
            if (Counter < _history.TurnLogs.Count - 1)
            {
                Counter++;
                HttpContext.Session.SetInt32("Counter", Counter);
                CurrentLog = _history.TurnLogs[Counter];
            }
        }
        else if (action == "back")
        {
            if (Counter > 0)
            {
                Counter--;
                HttpContext.Session.SetInt32("Counter", Counter);
                CurrentLog = _history.TurnLogs[Counter];
            }
        }
    }
}
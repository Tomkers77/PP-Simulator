namespace Simulator;
public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }
    private void Run()
    {
        while (!_simulation.Finished)
        {
            var currentCreature = _simulation.CurrentCreature;
            var currentMove = _simulation.CurrentMoveName;
            var log = new SimulationTurnLog
            {
                Mappable = currentCreature.ToString(),
                Move = currentMove,
                Symbols = GetMapSymbols()
            };

            TurnLogs.Add(log);
            Console.Write("LOG: " + log);

            _simulation.Turn();
        }
    }
    private Dictionary<Point, char> GetMapSymbols()
    {
        var symbols = new Dictionary<Point, char>();

        for (int x = 0; x < _simulation.Map.SizeX; x++)
        {
            for (int y = 0; y < _simulation.Map.SizeY; y++)
            {
                var point = new Point(x, y);

                var creatures = _simulation.Map.At(point);

                var numberofCreatures = creatures.Count();
                if (creatures.Count() == 1)
                {
                    symbols[point] = creatures[0].Symbol;
                }
                else if (numberofCreatures > 1)
                {
                    symbols[point] = 'X';
                }
            }
        }
        return symbols;
    }
}
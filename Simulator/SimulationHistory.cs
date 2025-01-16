namespace Simulator;
public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

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
            // Stwórz log dla obecnej tury
            var log = new SimulationTurnLog
            {
                Mappable = currentCreature.ToString(),
                Move = currentMove,
                Symbols = GetMapSymbols()
            };
            // Dodaj log do historii
            TurnLogs.Add(log);
            Console.Write("LOG: " + log);
            // Wykonaj jeden krok symulacji
            _simulation.Turn();
        }
    }
    private Dictionary<Point, char> GetMapSymbols()
    {
        var symbols = new Dictionary<Point, char>();
        // Iteruj przez każdy punkt na mapie
        for (int x = 0; x < _simulation.Map.SizeX; x++)
        {
            for (int y = 0; y < _simulation.Map.SizeY; y++)
            {
                var point = new Point(x, y);
                // Pobierz obiekty znajdujące się w tej pozycji
                var creatures = _simulation.Map.At(point);
                // Jeśli są obiekty, wybierz symbol pierwszego
                if (creatures.Count() != 0)
                {
                    symbols[point] = creatures[0].Symbol;
                }
            }
        }
        return symbols;
    }
}
using Simulator.Maps;
using Simulator;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<IMappable> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    //----------------------------------------------------------------------------------------------------------------

    private int _licznik = 0;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public IMappable CurrentCreature
    {
        get
        {
            return Creatures[_licznik %  Creatures.Count];
        }
    }

    //----------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName 
    {
        get
        {
            return Moves[_licznik % Moves.Length].ToString().ToLower();
        } 
    }

    //------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> creatures,
        List<Point> positions, string moves)
    {
        Map = map; 
        Creatures = creatures;
        Positions = positions;
       

        
        List<Direction> directions = DirectionParser.Parse(moves);

        for (int i = 0; i < directions.Count; i++)
        {
            Moves += directions[i].ToString().ToLower().First();
        }
        

        if (Creatures.Count == 0)
        {
            throw new ArgumentException("Lista stworow jest pusta");
        }

        if (Creatures.Count != Positions.Count)
        {
            throw new ArgumentException("Liczba stworow i liczba pozycji musi byc taka sama");
        }

        
        for (int i = 0; i < Creatures.Count; i++)
        {
            Creatures[i].InitMapAndPosition(map, positions[i]);
        }
        
    }

    //-----------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() 
    { 
        if (Finished == true)
        {
            throw new InvalidOperationException("Symulacja zostala zakonczona");
        }

        IMappable creature = CurrentCreature;
        string move = CurrentMoveName;

        
        List<Direction> directions = DirectionParser.Parse(move);

        if (directions.Count > 0)
        {
          
            creature.Go(directions[_licznik % directions.Count]);
            
        }

        _licznik++;

        
        if (_licznik >=  Moves.Length)
        {
            Finished = true;
        }

    }
}
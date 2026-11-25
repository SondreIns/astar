using Godot;

namespace Astar;

public class NavCell
{
    // Tile position
    public Vector2I TilePos { get; }

    // Cost from cell to start
    public int Gcost { get; set; }

    // Cost from cell to target
    public int Hcost { get; set; }

    // Sum of Gcost and Hcost
    public int Fcost => Gcost + Hcost;

    public NavCell Connection { get; private set ;}

    public NavCell(Vector2I tilePos)
    {
        TilePos = tilePos;
    }

    // Connect cell to a neighbour for path.
    public void Connect(NavCell cell) => Connection = cell;
}
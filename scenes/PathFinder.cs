using Godot;
using System.Collections.Generic;

public partial class PathFinder : Node
{
    private TileMapLayer _walkable, _obstacle, _highlight;

    // might change to only take in vector2 coords, and send data back to main for drawing path

    // rough steps needed:
    /*
    2 sets - open and closed (open - list, closed - hashset?)

    -Add start node to OPEN

    loop
        current = node in OPEN with lowest fCost
        remove current from OPEN
        add current to CLOSED

        if current == target node: path found, return path

        foreach neighbour of current
            if neighbour == obstacle || neighbour == CLOSED
                skip to next neighbour
        
        if new path to neighbour is shorter || neighbour is not in OPEN
            set fCost of neighbour
            set parent of neighbour to current
            if neighbour is not in OPEN
                add neighbour to OPEN

    */
}
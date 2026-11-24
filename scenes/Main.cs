using Astar.Data;
using Godot;
using System;

namespace Astar;
public partial class Main : Node
{
    [ExportGroup("TileMaps")]
    [Export] private TileMapLayer _walkable, _obstacle, _highlight;
    [ExportGroup("Nodes")]
    [Export] private TileNode _startNode, _endNode;

    public override void _Ready()
    {
        GD.Print($"Start pos: {_startNode.TilePos}");
        GD.Print($"End pos: {_endNode.TilePos}");
    }

}

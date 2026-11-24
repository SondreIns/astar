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

    public override void _Process(double delta)
    {
        DebugHiglightInput();
    }





    // DEBUG---------------------------------------------------------------
    private void DebugRandomTileHighlightDir(Vector2I start)
    {
        _highlight.Clear();
        Vector2I dir = Vector2I.Zero;
        while(dir.X == 0 && dir.Y == 0)
        {
            dir = new Vector2I(GD.RandRange(-1, 1), GD.RandRange(-1, 1));
        }

        int distance = GD.RandRange(1, 10);

        for(int i = 0; i < distance; i++)
        {
            _highlight.SetCell(start + dir*i, 0, Vector2I.Zero);

        }
    }

    private void DebugHiglightInput()
    {
        if(Input.IsActionJustPressed(ProjectConstants.DEBUG_1)) DebugRandomTileHighlightDir(_startNode.TilePos);
    }
}

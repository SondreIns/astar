using Astar.Data;
using Godot;
using System;
using System.Collections.Generic;

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
        DebugPathFindInput();
    }

    private Vector2I[] FindShortestPath(Vector2I start, Vector2I end)
    {
        List<Vector2I> result = new();
        Vector2I currentPos = start;
        while(currentPos != end)
        {
            Vector2I newPos = currentPos;
            if(newPos.Y > end.Y) newPos.Y -= 1;
            else if (newPos.Y < end.Y) newPos.Y += 1;

            if(newPos.X > end.X) newPos.X -= 1;
            else if (newPos.X < end.X) newPos.X += 1;

            result.Add(newPos);
            currentPos = newPos;
        }

        return result.ToArray();
    }

    private void HighlightFullPath(Vector2I[] path)
    {
        _highlight.Clear();
        foreach(Vector2I cell in path) _highlight.SetCell(cell, 0, Vector2I.Zero);
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

    private void DebugPathFindInput()
    {
        if(Input.IsActionJustPressed(ProjectConstants.DEBUG_2)) HighlightFullPath(FindShortestPath(_startNode.TilePos, _endNode.TilePos));
    }
}

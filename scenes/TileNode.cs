using Astar.Data;
using Godot;
using System;

public partial class TileNode : Node2D
{
    [Export] public bool IsStartNode { get; private set; }

    public Vector2I TilePos => (Vector2I)GlobalPosition / ProjectConstants.TILE_SIZE;

    private Sprite2D _region;

    public override void _Ready()
    {
        _region = GetNode<Sprite2D>("Sprite2D");
        if(!IsStartNode) _region.RegionRect = new Rect2(new Vector2(96, 0), new Vector2(32, 32));
    }

    public void Move(Vector2I targetPos)
    {
        GlobalPosition = targetPos * ProjectConstants.TILE_SIZE;
    }

}

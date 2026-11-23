using Godot;
using System;

public partial class TileNode : Node2D
{
    [Export] public bool IsStartNode { get; private set; }

    private Sprite2D _region;

    public override void _Ready()
    {
        _region = GetNode<Sprite2D>("Sprite2D");
        if(!IsStartNode) _region.RegionRect = new Rect2(new Vector2(96, 0), new Vector2(32, 32));
    }

}

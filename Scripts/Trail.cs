using Godot;
using System;

public class Trail : Line2D
{
    int length = 50;

    Vector2 point = Vector2.Zero;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        GlobalPosition = Vector2.Zero;
        GlobalRotation = 0;

        point = ((Node2D)GetParent()).GlobalPosition;

        AddPoint(point);

        while (GetPointCount() > length)
        {
            RemovePoint(0);
        }
    }
}

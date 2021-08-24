using Godot;
using System;

public class ThrowGrenade : Node
{
    PackedScene grenadeScene = new PackedScene();
    //The selected grenade to throw will be set in this class i think

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        grenadeScene = ResourceLoader.Load("res://Scenes/Grenades/Grenade.tscn") as PackedScene;
    }

    private void Throw()
    {
        Node2D grenade = grenadeScene.Instance() as Node2D;
        grenade.Position = ((Node2D)GetParent()).GlobalPosition;
        AddChild(grenade);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("left_mouse"))
        {
            Throw();
        }
    }
}

using Godot;
using System;

public class Grenade : RigidBody2D
{
    //The blast area for hte grenade
    Area2D blastArea;
    Timer detonateTimer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ApplyImpulse(Vector2.Zero, new Vector2(Mathf.Cos(Rotation), Mathf.Sin(Rotation)) * 1000);

        detonateTimer = GetNode<Timer>("DetonateTimer");

        blastArea = GetNode<Area2D>("BlastArea");

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (detonateTimer.TimeLeft == 0)
        {
            QueueFree();
            //Call explosion animation
            //call hit event for all in the area

        }
    }
}

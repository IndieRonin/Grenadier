using Godot;
using System;

public class Explosion : Node2D
{
    Particles2D dust;
    Particles2D explosion;
    Particles2D sparks;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        dust = GetNode<Particles2D>("Dust");
        explosion = GetNode<Particles2D>("Explosion");
        sparks = GetNode<Particles2D>("Sparks");

        dust.Emitting = true;
        explosion.Emitting = true;
        sparks.Emitting = true;
    }

    public void OnLifeTimerTimeout()
    {
        QueueFree();
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}

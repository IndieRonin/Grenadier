using Godot;
using System;

public class Explosion : AnimatedSprite
{


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Playing = true;
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

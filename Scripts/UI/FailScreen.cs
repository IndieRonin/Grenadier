using Godot;
using System;
public class FailScreen : Node2D
{
    public void OnExitButtonUp()
    {
        QueueFree();
    }
}

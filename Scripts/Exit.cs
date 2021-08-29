using Godot;
using System;
using EventCallback;
public class Exit : Area2D
{
    public override void _Ready()
    {

    }
    public void OnExitBodyEntered(RigidBody2D body)
    {
        if (!body.IsInGroup("Player")) return;
        ChangeGameStateEvent cgsei = new ChangeGameStateEvent();
        cgsei.callerClass = "Exit: OnExitBodyEntered";
        cgsei.newState = GameStates.WIN;
        cgsei.FireEvent();
    }
}

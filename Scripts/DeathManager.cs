using Godot;
using System;
using EventCallback;
public class DeathManager : Node2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        DeathEvent.RegisterListener(OnDeathEvent);
    }

    private void OnDeathEvent(DeathEvent dei)
    {
        //Call blood splatter vfx
        //if death was players the call game over
        if (((Node2D)GD.InstanceFromId(dei.targetID)).IsInGroup("Player"))
        {
            GD.Print("Player died");
            ChangeGameStateEvent cgsei = new ChangeGameStateEvent();
            cgsei.callerClass = "DeathManager: OnDeathEvent()";
            cgsei.newState = GameStates.FAIL;
            cgsei.FireEvent();
        }
        GD.Print("Something has died");
    }


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}

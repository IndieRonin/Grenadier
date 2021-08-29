using Godot;
using System;
using EventCallback;
public class Camera : Camera2D
{
    float speed;

    Node2D target;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        SetCameraTargetEvent.RegisterListener(OnSetCameraTargetEvent);
    }

    private void OnSetCameraTargetEvent(SetCameraTargetEvent sctei)
    {
        //If the target for the camera is to be reset
        if (sctei.resetTarget)
        {
            //We reset the cameras target to the base scene
            OnResetCameraTarget();
            //Return out of the function so no further code is run
            return;
        }

        //Set the target to the NodeID passed into the function
        target = GD.InstanceFromId(sctei.targetID) as Node2D;
        //Reset the cameras target
        OnResetCameraTarget();
        //Add the camera as a child 
        target.AddChild(this);
    }

    private void OnResetCameraTarget()
    {
        //If the camera node has a parent
        if (GetParent() != null)
        {
            //The camera removes itself from the parent
            GetParent().RemoveChild(this);
        }
    }

    public override void _ExitTree()
    {
        base._ExitTree();
        SetCameraTargetEvent.UnregisterListener(OnSetCameraTargetEvent);

    }
}

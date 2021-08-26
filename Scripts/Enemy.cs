using Godot;
using System;
using EventCallback;
public class Enemy : RigidBody2D
{
    //The ray to see if the player is in sight of the enemie
    RayCast2D los;
    Node2D target;
    //The speed of the enemie
    [Export] float speed;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Reference the ray
        los = GetNode<RayCast2D>("LOSRay");
        HitEvent.RegisterListener(OnHitEvent);

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        if (target == null) return;
        AddForce(Vector2.Zero, (target.GlobalPosition - GlobalPosition).Normalized() * speed);
        LookAt(target.GlobalPosition);
    }

    private void OnHitEvent(HitEvent hei)
    {
        if (hei.targetID == GetInstanceId())
        {
            GD.Print("Enemy - OnHitEvent(): hei.targetID = " + hei.targetID);
            GD.Print("Enemy - OnHitEvent(): GetInstanceId() = " + GetInstanceId());
            //Play death animation
            QueueFree();
        }
    }

    public void OnArea2DBodyEntered(RigidBody2D body)
    {
        if (body.IsInGroup("Player"))
        {
            target = body as Node2D;
        }
    }
    public void OnArea2DBodyExited(RigidBody2D body)
    {
        if (body.IsInGroup("Player"))
        {
            target = null;
        }
    }

    //Check if the player has entered the area of the enemy
    //If the player is in range start the ray cast to see if the player is in sight
    //If the player is in line of sight then movetowards player
    //If the player is in a certain range then call hit event in the players ID

    public override void _ExitTree()
    {
        base._ExitTree();
        HitEvent.UnregisterListener(OnHitEvent);
    }
}

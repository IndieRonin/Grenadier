using Godot;
using System;
using EventCallback;
public class Enemy : RigidBody2D
{
    //The ray to see if the player is in sight of the enemie
    RayCast2D los;
    Node2D target;
    //The speed of the enemie
    float speed = 10000;
    //If the enemy can attack
    bool canAttack = true;
    //The attack timer in the scene
    Timer attackTimer;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Reference the ray
        los = GetNode<RayCast2D>("LOSRay");
        HitEvent.RegisterListener(OnHitEvent);
        attackTimer = GetNode<Timer>("AttackTimer");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        if (target == null) return;
        //Counter the parents rotation to have the Raycast go in the right direction
        los.Rotation = -Rotation;
        los.CastTo = target.GlobalPosition - GlobalPosition;
        //Set the ray to active to check for collisions
        los.Enabled = true;
        //Force the raycast to cast to update hte collsions, enable if the collsion are not picking up fast enough
        //los.ForceRaycastUpdate();
        if (los.IsColliding())
        {
            if (((Node2D)los.GetCollider()).IsInGroup("Player"))
            {
                Vector2 dir = GlobalPosition.DirectionTo(target.GlobalPosition);
                LinearVelocity = dir * speed * delta;
            }
        }
        LookAt(target.GlobalPosition);

        if (GlobalPosition.DistanceTo(target.GlobalPosition) < 18 && canAttack)
        {
            HitEvent hei = new HitEvent();
            hei.callerClass = "Enemy: _PhysicsProcess()";
            hei.targetID = target.GetInstanceId();
            hei.FireEvent();
            //Set the can attack variable to false until the attack timer has run out
            canAttack = false;
            //Start the attack timer
            attackTimer.Start();
        }
    }

    public void OnAttackTimerTimeout()
    {
        canAttack = true;
    }

    private void OnHitEvent(HitEvent hei)
    {
        if (hei.targetID == GetInstanceId())
        {
            DeathEvent dei = new DeathEvent();
            dei.callerClass = "Enemy: OnHitEvent()";
            dei.targetID = GetInstanceId();
            dei.FireEvent();

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

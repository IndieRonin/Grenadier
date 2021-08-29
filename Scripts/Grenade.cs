using Godot;
using System;
using System.Collections.Generic;
using EventCallback;
public class Grenade : RigidBody2D
{
    Timer detonateTimer;

    //List of bodies in the blast area
    List<ulong> bodiesList = new List<ulong>();

    PackedScene explosionScene = new PackedScene();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Load the scene for the explosion
        explosionScene = ResourceLoader.Load("res://Scenes/VFX/Explosion.tscn") as PackedScene;
        //When the grenade is created i nthe scene we add an impulse fore to it in the direction of hte mouses position
        ApplyImpulse(Vector2.Zero, (GetGlobalMousePosition() - GlobalPosition).Normalized() * 500);
        //Start the detonators timer
        detonateTimer = GetNode<Timer>("DetonateTimer");
        //Hit listener for the grenade
        HitEvent.RegisterListener(OnHitEvent);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (detonateTimer.TimeLeft == 0)
        {
            Explode();
        }
    }

    private void OnHitEvent(HitEvent hei)
    {
        if (hei.targetID == GetInstanceId())
        {
            //Explode();
        }
    }

    private void Explode()
    {
        foreach (ulong id in bodiesList)
        {
            HitEvent hei = new HitEvent();
            hei.callerClass = "Grenade - _Process()";
            hei.targetID = id;
            hei.FireEvent();
        }

        Node2D explosion = explosionScene.Instance() as Node2D;
        explosion.GlobalPosition = GlobalPosition;
        GetTree().Root.AddChild(explosion);

        QueueFree();
        //Call explosion animation
    }

    public void OnBlastAreaBodyEntered(RigidBody2D body)
    {
        if (bodiesList.Contains(body.GetInstanceId())) return;
        if (body.GetInstanceId() == GetInstanceId()) return;
        bodiesList.Add(body.GetInstanceId());
    }

    public void OnBlastAreaBodyExited(RigidBody2D body)
    {
        if (!bodiesList.Contains(body.GetInstanceId())) return;
        bodiesList.Remove(body.GetInstanceId());
    }
    public override void _ExitTree()
    {
        base._ExitTree();
        HitEvent.UnregisterListener(OnHitEvent);
    }
}

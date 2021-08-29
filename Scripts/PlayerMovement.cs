using Godot;
using System;
using EventCallback;
public class PlayerMovement : RigidBody2D
{

    public float speed = 300;
    public float accel = 10000;
    public float decel = 0; //????????????????????????????????? does not effect player
    Vector2 inputDirection = Vector2.Zero;
    public Vector2 velocity = new Vector2();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        HitEvent.RegisterListener(OnHitEvent);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        if (inputDirection == Vector2.Zero)
        {
            ApplyFriction(decel * delta);
        }
        else
        {
            ApplyMovement(inputDirection * accel * delta);
        }

        LinearVelocity = velocity;
        LookAt(GetGlobalMousePosition());
    }

    private void GetInput()
    {
        velocity = new Vector2();

        inputDirection.x = Input.GetActionStrength("key_d") - Input.GetActionStrength("key_a");
        inputDirection.y = Input.GetActionStrength("key_s") - Input.GetActionStrength("key_w");
        inputDirection = inputDirection.Normalized();
    }

    private void ApplyFriction(float amount)
    {
        if (velocity.Length() > amount)
        {
            velocity -= velocity.Normalized() * amount;
        }
        else
        {
            velocity = Vector2.Zero;
        }
    }

    private void ApplyMovement(Vector2 _accel)
    {
        velocity += _accel;
        velocity = velocity.Clamped(speed);
    }

    private void OnHitEvent(HitEvent hei)
    {
        if (hei.targetID != GetInstanceId()) return;

        DeathEvent dei = new DeathEvent();
        dei.callerClass = "PlayerMovement: OnHitEvent()";
        dei.targetID = GetInstanceId();
        dei.FireEvent();

        QueueFree();
    }

}

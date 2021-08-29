using Godot;
using System;
using EventCallback;
public class Health : Node
{
    //Make the health of the enemy tank set able outside in the inspector
    [Export] int health = 100;
    [Export] int damage = 50;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        HitEvent.RegisterListener(OnHitEvent);
    }
    private void OnHitEvent(HitEvent hei)
    {
        if (hei.targetID == GetParent().GetInstanceId())
        {
            health -= damage;
            //Check if the health has gone down to zero
            CheckHealth();
        }
    }
    private void CheckHealth()
    {
        if (health <= 0)
        {
            //Make sure the health does not go below 0
            health = 0;
            Die();
        }
    }
    void Die()
    {
        // I am dying for some reason.
        DeathEvent dei = new DeathEvent();
        dei.callerClass = "Health: Die()";
        dei.targetID = GetParent().GetInstanceId();
        dei.FireEvent();

        //Remove the parent node forn the scene
        QueueFree();
    }
    public override void _ExitTree()
    {
        HitEvent.UnregisterListener(OnHitEvent);
    }
}


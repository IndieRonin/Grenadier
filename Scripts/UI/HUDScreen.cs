using Godot;
using System;
using EventCallback;
public class HUDScreen : Node2D
{
    Label health;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        health = GetNode<Label>("lblHealth");

        UpdateHUD.RegisterListener(OnUpdateHUD);
    }

    private void OnUpdateHUD(UpdateHUD uhudi)
    {
        health.Text = "Health " + (uhudi.health).ToString();
    }
}

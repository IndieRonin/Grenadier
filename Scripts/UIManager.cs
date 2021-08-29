using Godot;
using System;
using EventCallback;

public enum UIStates
{
    TITLE,
    CREDITS,
    OPTIONS,
    MENU,
    HUD,
    FAIL
};
public class UIManager : CanvasLayer
{
    Node2D titleScreen;
    Node2D creditsScreen;
    Node2D optionsScreen;
    Node2D menuScreen;
    Node2D hudScreen;
    Node2D failScreen;

    UIStates currentState;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ChangeUIStateEvent.RegisterListener(OnChangeUIStateEvent);

        titleScreen = GetNode<Node2D>("TitleScreen");
        creditsScreen = GetNode<Node2D>("CreditsScreen");
        optionsScreen = GetNode<Node2D>("OptionsScreen");
        menuScreen = GetNode<Node2D>("MenuScreen");
        hudScreen = GetNode<Node2D>("HUDScreen");
        failScreen = GetNode<Node2D>("FailScreen");

        HideAllUI();

        titleScreen.Visible = true;
        currentState = UIStates.TITLE;
    }

    private void OnChangeUIStateEvent(ChangeUIStateEvent cuisei)
    {
        if (currentState == cuisei.newState) return;

        currentState = cuisei.newState;

        HideAllUI();

        switch (cuisei.newState)
        {
            case UIStates.TITLE:
                titleScreen.Visible = true;
                break;
            case UIStates.CREDITS:
                creditsScreen.Visible = true;
                break;
            case UIStates.HUD:
                hudScreen.Visible = true;
                break;
            case UIStates.MENU:
                menuScreen.Visible = true;
                break;
            case UIStates.OPTIONS:
                optionsScreen.Visible = true;
                break;
            case UIStates.FAIL:
                failScreen.Visible = true;
                break;
        }
    }

    private void HideAllUI()
    {
        titleScreen.Visible = false;
        creditsScreen.Visible = false;
        optionsScreen.Visible = false;
        menuScreen.Visible = false;
        hudScreen.Visible = false;
        failScreen.Visible = false;
    }
}

using Godot;
using System;
using EventCallback;

public class TitleScreen : Node2D
{
    public void OnStartButtonUp()
    {
        ChangeUIStateEvent cuisei = new ChangeUIStateEvent();
        cuisei.callerClass = "TitleScreen: OnStartButtonUp()";
        cuisei.newState = UIStates.HUD;
        cuisei.FireEvent();
    }
    public void OnOptionsButtonUp()
    {
        ChangeUIStateEvent cuisei = new ChangeUIStateEvent();
        cuisei.callerClass = "TitleScreen: OnOptionsButtonUp()";
        cuisei.newState = UIStates.OPTIONS;
        cuisei.FireEvent();
    }
    public void OnCreditsButtonUp()
    {
        ChangeUIStateEvent cuisei = new ChangeUIStateEvent();
        cuisei.callerClass = "TitleScreen: OnCreditsButtonUp()";
        cuisei.newState = UIStates.CREDITS;
        cuisei.FireEvent();
    }
    public void OnExitButtonUp()
    {
        GetTree().Quit();
    }
}

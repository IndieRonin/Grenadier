using Godot;
using System;
using EventCallback;
public class MenuScreen : Node2D
{
    public void OnOptionsButtonUp()
    {
        ChangeUIStateEvent cuisei = new ChangeUIStateEvent();
        cuisei.callerClass = "MenuScreen: OnOptionsButtonUp()";
        cuisei.newState = UIStates.OPTIONS;
        cuisei.FireEvent();
    }
    public void OnExitButtonUp()
    {
        QueueFree();
    }
    public void OnBackButtonUp()
    {
        ChangeUIStateEvent cuisei = new ChangeUIStateEvent();
        cuisei.callerClass = "MenuScreen: OnExitButtonUp";
        cuisei.newState = UIStates.TITLE;
        cuisei.FireEvent();
    }
}

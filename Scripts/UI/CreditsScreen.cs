using Godot;
using System;
using EventCallback;
public class CreditsScreen : Node2D
{
    public void OnBackButtonUp()
    {
        ChangeUIStateEvent cuisei = new ChangeUIStateEvent();
        cuisei.callerClass = "OptionsScreen: OnExitButtonUp";
        cuisei.newState = UIStates.TITLE;
        cuisei.FireEvent();
    }
}

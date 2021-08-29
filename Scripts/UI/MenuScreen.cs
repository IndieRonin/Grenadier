using Godot;
using System;
using EventCallback;
public class MenuScreen : Node2D
{
    Slider musicVolume;
    Slider soundVolume;

    public override void _Ready()
    {
        base._Ready();
        musicVolume = GetNode<Slider>("MusicVolume");
        soundVolume = GetNode<Slider>("SoundVolume");
    }

    public void OnMusicVolumeValueChanged()
    {
        ChangeVolumeEvent cvei = new ChangeVolumeEvent();
        cvei.callerClass = "OptionsScreen: OnMusicVolumeValueChanged()";
        cvei.musicVolume = (float)((musicVolume.Value * -80) / 100);
        cvei.FireEvent();
    }

    public void OnSoundVolumeValueChanged()
    {
        ChangeVolumeEvent cvei = new ChangeVolumeEvent();
        cvei.callerClass = "OptionsScreen: OnSoundVolumeValueChanged()";
        cvei.soundVolume = (float)((soundVolume.Value * -80) / 100);
        cvei.FireEvent();
    }

    public void OnOptionsButtonUp()
    {
        ChangeUIStateEvent cuisei = new ChangeUIStateEvent();
        cuisei.callerClass = "MenuScreen: OnOptionsButtonUp()";
        cuisei.newState = UIStates.OPTIONS;
        cuisei.FireEvent();
    }
    public void OnExitButtonUp()
    {
        GetTree().Quit();
    }
    public void OnBackButtonUp()
    {
        ChangeUIStateEvent cuisei = new ChangeUIStateEvent();
        cuisei.callerClass = "MenuScreen: OnExitButtonUp";
        cuisei.newState = UIStates.HUD;
        cuisei.FireEvent();
    }
}

using Godot;
using System;
using EventCallback;
public class OptionsScreen : Node2D
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

    public void OnBackButtonUp()
    {
        ChangeUIStateEvent cuisei = new ChangeUIStateEvent();
        cuisei.callerClass = "OptionsScreen: OnExitButtonUp";
        cuisei.newState = UIStates.TITLE;
        cuisei.FireEvent();
    }
}

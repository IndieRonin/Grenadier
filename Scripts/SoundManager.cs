using Godot;
using System;
using System.Collections.Generic;
using EventCallback;
public class SoundManager : Node2D
{
    AudioStreamPlayer musicPlayer;
    AudioStreamPlayer2D soundPlayer;

    [Export] AudioStreamSample musicGame;
    [Export] AudioStreamSample musicMenu;
    [Export] AudioStreamSample musicBattle;

    [Export] AudioStreamSample grenadeThrow;
    [Export] AudioStreamSample grenadeExplode;
    [Export] AudioStreamSample playerWalk;
    [Export] AudioStreamSample playerDie;
    [Export] AudioStreamSample playerHurt;
    [Export] AudioStreamSample monsterNoticePlayer;
    [Export] AudioStreamSample monsterRun;
    [Export] AudioStreamSample monsterDie;
    [Export] AudioStreamSample boxBreak;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ChangeVolumeEvent.RegisterListener(OnChangeVolumeEvent);
        ChangeGameStateEvent.RegisterListener(OnChangeGameStateEvent);
        musicPlayer = GetNode<AudioStreamPlayer>("MusicPlayer");
        soundPlayer = GetNode<AudioStreamPlayer2D>("SFX2D");
    }

    private void OnChangeVolumeEvent(ChangeVolumeEvent cvei)
    {
        musicPlayer.VolumeDb = cvei.musicVolume;
        soundPlayer.VolumeDb = cvei.soundVolume;
    }

    public void OnChangeGameStateEvent(ChangeGameStateEvent cgse)
    {
        //Switch between the 
        switch (cgse.newState)
        {
            case GameStates.START_SCREEN:
                break;
            case GameStates.GAME:
                break;
            case GameStates.MENU:
                break;
            case GameStates.WIN:
                break;
            case GameStates.FAIL:
                break;
        }
    }

    public override void _ExitTree()
    {
        base._ExitTree();
        ChangeVolumeEvent.UnregisterListener(OnChangeVolumeEvent);
        ChangeGameStateEvent.UnregisterListener(OnChangeGameStateEvent);
    }
}

using Godot;
using System;
using System.Collections.Generic;
using EventCallback;

//Testing github upload

//The states for the game main loop
public enum GameStates
{
    START_SCREEN,
    INIT,
    GAME,
    MENU,
    WIN,
    FAIL
};

public class Main : Node2D
{
    //The current state of the game
    private GameStates currentState;
    //The external list of persistant scenes
    [Export] private List<PackedScene> persistentScenes = new List<PackedScene>();
    //The external list of scenes to instantiate when the game is started from the main menu
    [Export] private List<PackedScene> gameScenes = new List<PackedScene>();
    //The list of nodes that will be used during the whole game and not destroyd n between scenes (Input, sound)
    private List<Node> persistentNodes = new List<Node>();
    //The list of nodes that will hold the pre loaded scenes
    private List<Node> gameNodes = new List<Node>();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Set the current state of the game at start up
        currentState = GameStates.START_SCREEN;
        //Register the listener for the game state changer
        ChangeGameStateEvent.RegisterListener(OnChangeGameStateEvent);
        //Check if the persistent scenes list is not zero 
        if (persistentScenes.Count > 0)
        {
            //Loop through all the scenes in the list
            foreach (PackedScene scene in persistentScenes)
            {
                //Add the node of the scenes
                persistentNodes.Add(scene.Instance());
            }
            //Loop through the list of scene nodes and add them to the current scene as children
            foreach (Node node in persistentNodes)
            {
                AddChild(node);
            }
        }
    }


    public override void _Process(float delta)
    {
        base._Process(delta);
        if (Input.IsActionJustPressed("key_escape"))
        {
            ChangeUIStateEvent cuisei = new ChangeUIStateEvent();
            cuisei.callerClass = "Main: _Process()";
            cuisei.newState = UIStates.MENU;
            cuisei.FireEvent();
        }
    }
    //NOTE: Needs to be added to the event listener system later
    //Changes the games state when recieving the change state message
    public void OnChangeGameStateEvent(ChangeGameStateEvent cgse)
    {
        //If hte new state is the same as the old one just exit out of the method without doing anything
        if (currentState == cgse.newState) return;
        //The new state of the game
        currentState = cgse.newState;
        //Switch between the 
        switch (currentState)
        {
            case GameStates.START_SCREEN:
                //Play title music
                break;
            case GameStates.INIT:
                //Check if the persistent scenes list is not zero 
                if (gameScenes.Count > 0)
                {
                    //Loop through all the scenes in the list
                    foreach (PackedScene scene in gameScenes)
                    {
                        //Add the node of the scenes
                        gameNodes.Add(scene.Instance());
                    }
                    //Loop through the list of scene nodes and add them to the current scene as children
                    foreach (Node node in gameNodes)
                    {
                        AddChild(node);
                    }
                }
                break;
            case GameStates.GAME:

                break;
            case GameStates.MENU:
                break;
            case GameStates.WIN:
                break;
            case GameStates.FAIL:
                ChangeUIStateEvent cuisei = new ChangeUIStateEvent();
                cuisei.callerClass = "Main: OnChangeGameStateEvent()";
                cuisei.newState = UIStates.FAIL;
                cuisei.FireEvent();
                break;
        }
    }
    public override void _ExitTree()
    {
        base._ExitTree();
        ChangeGameStateEvent.UnregisterListener(OnChangeGameStateEvent);
    }

}

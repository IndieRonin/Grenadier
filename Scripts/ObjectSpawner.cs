using Godot;
using System;
using System.Collections.Generic;
using EventCallback;
public class ObjectSpawner : Node2D
{

    private Vector2 playerSpawnPoint;
    private Vector2 exitPoint;
    private List<Vector2> enemySpawnsPoint = new List<Vector2>();
    private List<Vector2> grenadeSpawnsPoint = new List<Vector2>();

    [Export] public PackedScene playerScene = new PackedScene();
    [Export] public PackedScene camera2DScene = new PackedScene();
    [Export] public PackedScene exitScene = new PackedScene();
    [Export] public List<PackedScene> monsterScenes = new List<PackedScene>();
    [Export] public List<PackedScene> grenadeScenes = new List<PackedScene>();


    private Node2D playerNode;
    private Node2D camera2DNode;
    private Node2D exitNode;
    private List<Node2D> monsterNodes = new List<Node2D>();
    private List<Node2D> grenadeNodes = new List<Node2D>();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetPointsEvent gpei = new GetPointsEvent();
        gpei.callerClass = "ObjectSpawner: _Ready";
        gpei.FireEvent();

        playerSpawnPoint = gpei.playerSpawnPoint;
        enemySpawnsPoint = gpei.enemySpawnsPoint;
        exitPoint = gpei.exitPoint;
        grenadeSpawnsPoint = gpei.grenadeSpawnsPoint;


        GD.Print("playerSpawnPoint = " + playerSpawnPoint);
        playerNode = playerScene.Instance() as Node2D;
        playerNode.Position = playerSpawnPoint;
        GetParent().AddChild(playerNode);
        camera2DNode = camera2DScene.Instance() as Node2D;
        GetParent().AddChild(camera2DNode);
        exitNode = exitScene.Instance() as Node2D;
        exitNode.Position = exitPoint;
        GetParent().AddChild(exitNode);


        if (monsterScenes.Count > 0)
        {
            int i = 0;
            //Loop through all the scenes in the list
            foreach (PackedScene scene in monsterScenes)
            {
                //Add the node of the scenes
                monsterNodes.Add(scene.Instance() as Node2D);
            }

            foreach (Node2D node in monsterNodes)
            {
                node.Position = enemySpawnsPoint[i];
                GetParent().AddChild(node);
                i++;
            }
        }

        if (grenadeScenes.Count > 0)
        {
            int i = 0;
            //Loop through all the scenes in the list
            foreach (PackedScene scene in grenadeScenes)
            {
                //Add the node of the scenes
                grenadeNodes.Add(scene.Instance() as Node2D);
            }
            //Loop through the list of scene nodes and add them to the current scene as children
            foreach (Node2D node in grenadeNodes)
            {
                node.Position = grenadeSpawnsPoint[i];
                GetParent().AddChild(node);
                i++;
            }
        }
    }

}

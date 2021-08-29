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
    [Export] public PackedScene monsterScene = new PackedScene();
    [Export] public PackedScene grenadeScene = new PackedScene();


    private Node2D playerNode;
    private Node2D camera2DNode;
    private Node2D exitNode;
    private Node2D monsterNode;
    private Node2D grenadeNode;

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

        playerNode = playerScene.Instance() as Node2D;
        playerNode.Position = playerSpawnPoint;
        GetParent().AddChild(playerNode);
        camera2DNode = camera2DScene.Instance() as Node2D;
        GetParent().AddChild(camera2DNode);

        SetCameraTargetEvent sctei = new SetCameraTargetEvent();
        sctei.callerClass = "ObjectSpawner: _Ready()";
        sctei.targetID = playerNode.GetInstanceId();
        sctei.FireEvent();

        exitNode = exitScene.Instance() as Node2D;
        exitNode.Position = exitPoint;
        GetParent().AddChild(exitNode);

        if (enemySpawnsPoint.Count > 0)
        {
            for (int i = 0; i < enemySpawnsPoint.Count; i++)
            {
                //Add the node of the scenes
                monsterNode = monsterScene.Instance() as Node2D;
                monsterNode.Position = enemySpawnsPoint[i];
                GetParent().AddChild(monsterNode);
            }
        }

        if (grenadeSpawnsPoint.Count > 0)
        {
            for (int i = 0; i < grenadeSpawnsPoint.Count; i++)
            {
                //Add the node of the scenes
                grenadeNode = grenadeScene.Instance() as Node2D;
                grenadeNode.Position = grenadeSpawnsPoint[i];
                GetParent().AddChild(grenadeNode);
            }
        }
    }

}

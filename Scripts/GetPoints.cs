using Godot;
using System;
using System.Collections.Generic;
using EventCallback;
public class GetPoints : TileMap
{
    public Vector2 playerSpawnPoint;
    public Vector2 exitSpawnPoint;
    public List<Vector2> enemySpawnsPoint = new List<Vector2>();
    public List<Vector2> grenadeSpawnsPoint = new List<Vector2>();

    public Node2D playerPoint;
    public Node2D exitPoint;
    public Node monsterSpawnPoints;
    public Node grenadeSpawnPoints;

    public override void _Ready()
    {
        GetPointsEvent.RegisterListener(OnGetPointsEvent);

        playerPoint = GetNode<Node2D>("PlayerSpawn");
        exitPoint = GetNode<Node2D>("ExitSpawn");
        monsterSpawnPoints = GetNode<Node>("MonsterSpawnPoints");
        grenadeSpawnPoints = GetNode<Node>("GrenadeSpawnPoints");
    }

    public void OnGetPointsEvent(GetPointsEvent gpei)
    {
        playerSpawnPoint = playerPoint.Position;
        exitSpawnPoint = exitPoint.Position;
        for (int i = 0; i < monsterSpawnPoints.GetChildCount(); i++)
        {
            enemySpawnsPoint.Add(((Node2D)monsterSpawnPoints.GetChild(i)).Position);
        }

        for (int i = 0; i < grenadeSpawnPoints.GetChildCount(); i++)
        {
            grenadeSpawnsPoint.Add(((Node2D)grenadeSpawnPoints.GetChild(i)).Position);
        }

        gpei.playerSpawnPoint = playerSpawnPoint;
        gpei.exitPoint = exitSpawnPoint;
        gpei.enemySpawnsPoint = enemySpawnsPoint;
        gpei.grenadeSpawnsPoint = grenadeSpawnsPoint;
    }

    public override void _ExitTree()
    {
        base._ExitTree();
        GetPointsEvent.UnregisterListener(OnGetPointsEvent);
    }
}

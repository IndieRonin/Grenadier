using Godot;
using System;
using System.Collections.Generic;
using EventCallback;
public class GetPoints : TileMap
{
    [Export] public Vector2 playerSpawnPoint;
    [Export] public Vector2 exitPoint;
    [Export] public List<Vector2> enemySpawnsPoint;
    [Export] public List<Vector2> grenadeSpawnsPoint;

    public Node monsterSpawnPoints;
    public Node grenadeSpawnPoints;

    public void OnGetPointsEvent(GetPointsEvent gpei)
    {
        GetPointsEvent.RegisterListener(OnGetPointsEvent);
        playerSpawnPoint = GetNode<Node2D>("PlayerSpawn").Position;
        exitPoint = GetNode<Node2D>("ExitSpawn").Position;
        monsterSpawnPoints = GetNode<Node>("MonsterSpawnPoints");
        grenadeSpawnPoints = GetNode<Node>("GrenadeSpawnPoints");

        for (int i = 0; i < monsterSpawnPoints.GetChildCount(); i++)
        {
            enemySpawnsPoint.Add(((Node2D)monsterSpawnPoints.GetChild(i)).Position);
        }

        for (int i = 0; i < grenadeSpawnPoints.GetChildCount(); i++)
        {
            grenadeSpawnsPoint.Add(((Node2D)grenadeSpawnPoints.GetChild(i)).Position);
        }

        gpei.playerSpawnPoint = playerSpawnPoint;
        gpei.exitPoint = exitPoint;
        gpei.enemySpawnsPoint = enemySpawnsPoint;
        gpei.grenadeSpawnsPoint = grenadeSpawnsPoint;
    }
}

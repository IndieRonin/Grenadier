using Godot;
using System;
using System.Collections.Generic;

namespace EventCallback
{
    public class GetPointsEvent : Event<GetPointsEvent>
    {
        public Vector2 playerSpawnPoint;
        public Vector2 exitPoint;
        public List<Vector2> enemySpawnsPoint;
        public List<Vector2> grenadeSpawnsPoint;
    }
}

using Godot;
using System;

namespace EventCallback
{
    public class SetCameraTargetEvent : Event<SetCameraTargetEvent>
    {
        public ulong targetID;
        public bool resetTarget;
    }

}

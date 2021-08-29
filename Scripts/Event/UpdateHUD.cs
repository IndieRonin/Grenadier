using Godot;
using System;
namespace EventCallback
{
    public class UpdateHUD : Event<UpdateHUD>
    {
        public int health;
    }

}
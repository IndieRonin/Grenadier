using Godot;
using System;

namespace EventCallback
{
    public class ChangeUIStateEvent : Event<ChangeUIStateEvent>
    {
        //The new state to be sent in the event message
        public UIStates newState;
    }
}
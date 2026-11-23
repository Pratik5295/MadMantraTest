using System;
using UnityEngine;

namespace MMTest.GameEvents
{
    public interface IInputEvents
    {
        //Movement
        public event Action<Vector2> Move;

        //Look
        public event Action<Vector2> Look;

        //Interact
        public event Action Interact;

        //Sprint
        public event Action<bool> Sprint;
    }
}
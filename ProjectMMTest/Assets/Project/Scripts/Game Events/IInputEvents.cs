using System;
using UnityEngine;

namespace MMTest.GameEvents
{
    public interface IInputEvents
    {
        //Gameplay

        //Movement
        public event Action<Vector2> Move;

        //Look
        public event Action<Vector2> Look;

        //Interact
        public event Action Interact;

        //Sprint
        public event Action<bool> Sprint;


        //Puzzle

        //Point
        public event Action<Vector2> Point;

        //Click
        public event Action Click;

        //Cancel
        public event Action Back;
    }
}
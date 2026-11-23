using System;
using UnityEngine;

namespace MMTest.GameEvents
{
    public static class InputEvents
    {
        //Movement
        public static event Action<Vector2> OnInputMove;
        public static void BroadcastMove(Vector2 move) => OnInputMove?.Invoke(move);

        //Look
        public static event Action<Vector2> OnInputLook;
        public static void BroadcastLook(Vector2 look) => OnInputLook?.Invoke(look);

        //Interact
        public static event Action OnInteract;
        public static void BroadcastInteract() => OnInteract?.Invoke(); //Only for press, nothign for release for now

        //Sprint
        public static event Action<bool> OnSprint;
        public static void BroadcastSprint(bool sprint) => OnSprint?.Invoke(sprint);
    }
}
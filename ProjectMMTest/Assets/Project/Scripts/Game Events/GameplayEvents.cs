
using MMTest.Gameplay;
using System;
using UnityEngine;

namespace MMTest.GameEvents
{
    public static class GamePlayEvents
    {
        //Game Mode
        public static event Action<GameState> OnGameStateChanged;
        public static void BroadcastGameStateChanged(GameState newState) => OnGameStateChanged?.Invoke(newState);

        //Interactable 
        public static event Action<IInteractable> OnFocusedChanged;

        public static void RaiseFocusChanged(IInteractable interact) => OnFocusedChanged?.Invoke(interact);

        //Puzzle Input
        public static event Action<Vector2> OnPuzzleLookInput;

        public static void BroadcastPuzzleMousePos(Vector2 pos) => OnPuzzleLookInput?.Invoke(pos);
    }
}
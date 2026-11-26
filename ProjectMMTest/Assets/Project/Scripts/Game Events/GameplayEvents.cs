
using MMTest.Data;
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

        //Dialogue Events (Move to UI Events class TODO:)
        
        public static event Action<DialogueSO> OnDialogueStart;
        public static void RaiseDialogueStarted(DialogueSO dialogue) => OnDialogueStart?.Invoke(dialogue);

        public static event Action OnDialogueNext;
        public static void RaiseDialogueNext() => OnDialogueNext?.Invoke(); 

        public static event Action OnDialogueEnded;
        public static void RaiseDialogueEnded() => OnDialogueEnded?.Invoke();

        public static event Action<string> OnShowToasterMessage;
        public static void NotifyToasterMessage(string message) => OnShowToasterMessage?.Invoke(message);

    }
}

using MMTest.Gameplay;
using System;

namespace MMTest.GameEvents
{
    public static class GameplayEvents
    {
        //Interactable 
        public static event Action<IInteractable> OnFocusedChanged;

        public static void RaiseFocusChanged(IInteractable interact) => OnFocusedChanged?.Invoke(interact);
    }
}
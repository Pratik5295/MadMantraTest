using MMTest.GameEvents;
using MMTest.Gameplay.Player;
using UnityEngine;

namespace MMTest.Gameplay
{
    public class GameStateMachine : MonoBehaviour
    {
        private GamePlayer _player;
        private bool _isInitialized = false;

        public GameState CurrentState { get; private set; }

        //Various States
        public GameplayState GameplayState { get; } = new GameplayState();
        public DialogueState DialogueState { get; } = new DialogueState();


        public void Initialize(GamePlayer player)
        {
            _player = player;
            _isInitialized = true;

            ChangeMode(GameplayState); //Defaulted to Gameplay State

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }

        public void SwitchToGameplay() => ChangeMode(GameplayState);
        public void SwitchToPuzzleMode(PuzzleInteractor puzzle)
        {
            ChangeMode(new PuzzleState(puzzle));
        }

        public void SwitchToDialogueMode() => ChangeMode(DialogueState);



        private void ChangeMode(GameState newState)
        {
            CurrentState?.Exit(_player);
            CurrentState = newState;
            CurrentState?.Enter(_player);

           GamePlayEvents.BroadcastGameStateChanged(CurrentState);
        }

        private void Update()
        {
            if (!_isInitialized) return;

            CurrentState?.Tick(_player);
        }
    }
}
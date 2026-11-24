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
        public PuzzleState PuzzleState { get; } = new PuzzleState();


        public void Initialize(GamePlayer player)
        {
            _player = player;
            _isInitialized = true;

            ChangeMode(GameplayState); //Defaulted to Gameplay State

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }

        public void SwitchToGameplay() => ChangeMode(GameplayState);
        public void SwitchToPuzzleMode() => ChangeMode(PuzzleState);



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
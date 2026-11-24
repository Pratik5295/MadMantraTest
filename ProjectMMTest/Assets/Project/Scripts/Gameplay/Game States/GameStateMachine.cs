using MMTest.Gameplay.Player;
using System;
using UnityEngine;

namespace MMTest.Gameplay
{
    public class GameStateMachine : MonoBehaviour
    {
        private GamePlayer _player;
        private bool _isInitialized = false;

        public GameState CurrentState { get; private set; }
        public event Action<GameState> OnGameStateChanged; //Move to global class later


        public void Initialize(GamePlayer player)
        {
            _player = player;
            _isInitialized = true;

            ChangeMode(new GameplayState()); //Defaulted to Gameplay State
        }

        public void ChangeMode(GameState newState)
        {
            CurrentState?.Exit(_player);
            CurrentState = newState;
            CurrentState?.Enter(_player);

            OnGameStateChanged?.Invoke(CurrentState);
        }

        private void Update()
        {
            if (!_isInitialized) return;

            CurrentState?.Tick(_player);
        }
    }
}
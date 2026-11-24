using MMTest.Data;
using MMTest.GameEvents;
using UnityEngine;

namespace MMTest.Gameplay.Player
{
    public class PlayerComponent: MonoBehaviour
    {
        protected IInputEvents _input;
        protected PlayerConfig _config;
        protected GameStateMachine _stateMachine;

        private bool _isSubscribed = false;
        private bool _isInitialized = false;

        public GameStateMachine StateMachine => _stateMachine;

        public void Inititalize(IInputEvents input, PlayerConfig config, GameStateMachine state)
        {
            _input = input;
            _config = config;
            _stateMachine = state;
            _isInitialized = true;
            TrySubscribe();
        }

        protected virtual void OnEnable()
        {
            TrySubscribe();
        }

        protected virtual void OnDisable()
        {
            TryUnsubscribe();
        }

        private void TrySubscribe()
        {
            if(!_isInitialized || _isSubscribed || !isActiveAndEnabled) return;

            Subscribe();

            _isSubscribed = true;
        }

        private void TryUnsubscribe()
        {
            if (!_isSubscribed) return;
            Unsubscribe();

            ResetInputs();

            _isSubscribed = false;
        }

        protected virtual void Subscribe() 
        {
            //No op
        }
        protected virtual void Unsubscribe() 
        {
           
        }

        protected virtual void ResetInputs() { }

    }
}
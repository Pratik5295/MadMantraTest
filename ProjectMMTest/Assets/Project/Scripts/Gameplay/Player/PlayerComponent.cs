using MMTest.Data;
using MMTest.GameEvents;
using UnityEngine;

namespace MMTest.Gameplay.Player
{
    public class PlayerComponent: MonoBehaviour
    {
        protected IInputEvents _input;
        protected PlayerConfig _config;

        private bool _isSubscribed = false;
        private bool _isInitialized = false;

        public void Inititalize(IInputEvents input, PlayerConfig config)
        {
            _input = input;
            _config = config;
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
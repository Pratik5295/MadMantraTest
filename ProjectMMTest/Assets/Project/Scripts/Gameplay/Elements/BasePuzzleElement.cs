using System;
using UnityEngine;
using UnityEngine.Events;

namespace MMTest.Gameplay
{
    public class BasePuzzleElement : MonoBehaviour, IPuzzleElement
    {
        private bool _isPressed = false; //Starts with default off state

        [SerializeField]
        private UnityEvent OnInteracted; //Setup in engine for pressed state
        [SerializeField]
        private UnityEvent OnUnInteracted; //Unpressed state

        public Action<bool> OnStateChange;
        public virtual void Interact()
        {
            ToggleState();
        }

        private void ToggleState()
        {
            if (_isPressed)
            {
                OnUnInteracted?.Invoke();
                OnStateChange?.Invoke(false);
            }
            else
            {
                OnInteracted?.Invoke();
                OnStateChange?.Invoke(true);
            }
            _isPressed = !_isPressed;
        }
    }
}
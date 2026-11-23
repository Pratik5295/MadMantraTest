using MMTest.GameEvents;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MMTest.Input
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Project/Input/Create Input Reader")]
    public class InputReader : ScriptableObject,IInputEvents, Controls.IPlayerActions
    {
        public event Action<Vector2> Move;
        public event Action<Vector2> Look;
        public event Action Interact;
        public event Action<bool> Sprint;

        private Controls _controls;

        #region Controls Callbacks

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.started)
                Interact?.Invoke();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            if (context.performed)
                Look?.Invoke(context.ReadValue<Vector2>());
            else if (context.canceled)
                Look?.Invoke(Vector2.zero);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
                Move?.Invoke(context.ReadValue<Vector2>());
            else if (context.canceled)
                Move?.Invoke(Vector2.zero);
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            if (context.started)
                Sprint?.Invoke(true);
            else if (context.canceled)
                Sprint?.Invoke(false);
        }

        #endregion


        private void OnEnable()
        {
            if(_controls == null)
            {
                _controls = new Controls();
                _controls.Player.SetCallbacks(this);
            }

            _controls.Player.Enable();
        }

        private void OnDisable()
        {
            _controls?.Player.Disable();
        }

    }
}
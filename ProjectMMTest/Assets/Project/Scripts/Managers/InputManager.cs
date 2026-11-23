using MMTest.GameEvents;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MMTest.Input
{
    public class InputManager : MonoBehaviour, Controls.IPlayerActions
    {
        private Controls _controls;

        #region Controls Callbacks

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.started)
                InputEvents.BroadcastInteract();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            if (context.performed)
                InputEvents.BroadcastLook(context.ReadValue<Vector2>());
            else if (context.canceled)
                InputEvents.BroadcastLook(Vector2.zero);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
                InputEvents.BroadcastMove(context.ReadValue<Vector2>());
            else if (context.canceled)
                InputEvents.BroadcastMove(Vector2.zero);
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            if (context.started)
                InputEvents.BroadcastSprint(true);
            else if (context.canceled)
                InputEvents.BroadcastSprint(false);
        }

        #endregion

        private void Awake()
        {
            _controls = new Controls();
            _controls.Player.AddCallbacks(this);
        }

        private void OnEnable()
        {
            _controls.Player.Enable();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }

        private void OnDestroy()
        {
            _controls.Dispose();
            _controls = null;
        }
    }
}
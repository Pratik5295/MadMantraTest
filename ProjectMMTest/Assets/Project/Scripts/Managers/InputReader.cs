using MMTest.GameEvents;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MMTest.Input
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Project/Input/Create Input Reader")]
    public class InputReader : ScriptableObject,IInputEvents, Controls.IPlayerActions, Controls.IPuzzleActions
    {
        public event Action<Vector2> Move;
        public event Action<Vector2> Look;
        public event Action Interact;
        public event Action<bool> Sprint;


        public event Action<Vector2> Point;
        public event Action Click;
        public event Action Back;

        private Controls _controls;

        #region Controls Callbacks

        //Gameplay State
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

        //Puzzle State
        public void OnPoint(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Point?.Invoke(context.ReadValue<Vector2>());
            }
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Click?.Invoke();
            }
        }

        public void OnBack(InputAction.CallbackContext context)
        {
            if(context.started)
                Back?.Invoke();
        }

        #endregion


        private void OnEnable()
        {
            if(_controls == null)
            {
                _controls = new Controls();
                _controls.Player.SetCallbacks(this);
            }
        }

        private void OnDisable()
        {
            DisableAllInput();
        }

        #region Input Switching Section
        private void EnablePlayerInput()
        {
            _controls.Player.Enable();
        }

        private void DisablePlayerInput()
        {
            _controls?.Player.Disable();
        }

        private void EnablePuzzleInput()
        {
            _controls.Puzzle.Enable();
        }

        private void DisablePuzzleInput()
        {
            _controls?.Puzzle.Disable();
        }

        //State handling
        public void SwitchToGameplayInput()
        {
            EnablePlayerInput();
            DisablePuzzleInput();
        }
        public void SwitchToPuzzleInput()
        {
            EnablePuzzleInput();
            DisablePlayerInput();
        }

        public void DisableAllInput()
        {
            DisablePlayerInput();
            DisablePuzzleInput();
        }

        #endregion
    }
}
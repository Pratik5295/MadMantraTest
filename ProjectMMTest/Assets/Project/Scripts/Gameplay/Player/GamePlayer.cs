using MMTest.Data;
using MMTest.GameEvents;
using MMTest.Input;
using UnityEngine;
using System.Collections.Generic;

namespace MMTest.Gameplay.Player
{
    [DefaultExecutionOrder(-5)]
    public class GamePlayer : MonoBehaviour
    {
        [SerializeField]
        private List<PlayerComponent> _components = new List<PlayerComponent>();

        [SerializeField]
        private GameStateMachine _stateMachine;

        [SerializeField]
        private InputReader _inputReader;
        [SerializeField]
        private PlayerConfig _config;

        private PlayerMovement _playerMovement;
        private PlayerLook _playerLook;
        private PlayerInteractor _playerInteractor;
        private PlayerPuzzleComponent _playerPuzzleComponent; //Handles all the pouzzle related inputs and interactions
        private PlayerDialogueComponent _playerDialogueComponent;

        private IInputEvents _input => _inputReader;

        private void Awake()
        {
            if (_input == null)
                Debug.LogError("Missing Input Reader");

            InitializeComponents();

        }

        private void InitializeComponents()
        {
            if (_components == null || _components.Count == 0) return;

            foreach (var component in _components)
            {
                if(component is PlayerMovement) _playerMovement = (PlayerMovement)component;
                if(component is PlayerLook) _playerLook = (PlayerLook)component;
                if(component is PlayerInteractor) _playerInteractor = (PlayerInteractor)component;
                if(component is PlayerPuzzleComponent) _playerPuzzleComponent = (PlayerPuzzleComponent)component;
                if(component is PlayerDialogueComponent) _playerDialogueComponent = (PlayerDialogueComponent)component;

                component.Inititalize(_input, _config, _stateMachine);
            }

            _stateMachine.Initialize(this);
        }

        #region State Handling

        public void SetControls(bool movement, bool look, bool interact, bool puzzle, bool dialogue)
        {
            //Set whatever is allowed
            _playerMovement.enabled = movement;
            _playerLook.enabled = look;
            _playerInteractor.enabled = interact;
            _playerPuzzleComponent.enabled = puzzle;
            _playerDialogueComponent.enabled = dialogue;
        }

        public void SwitchToGameplayInput() => _inputReader.SwitchToGameplayInput();
        public void SwitchToPuzzleInput() => _inputReader.SwitchToPuzzleInput();
        public void DisableAllInput() => _inputReader.DisableAllInput();

        #endregion

        #region Context Menu Methods
        //Context menu functions for quick setup
        [ContextMenu("Setup Player Components")]
        public void SetupPlayerComponents()
        {
            _components.Clear();

            var components = GetComponents<PlayerComponent>();

            foreach(var component in components)
            {
                _components.Add(component);
            }
        }

        #endregion
    }
}
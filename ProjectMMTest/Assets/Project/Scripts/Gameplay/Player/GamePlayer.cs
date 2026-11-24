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

        private IInputEvents _input => _inputReader;

        private void Awake()
        {
            if (_input == null)
                Debug.LogError("Missing Input Reader");

            InitializeComponents();

        }

        private void Start()
        {
            EnablePlayerInput();   //Keeping it active by default for now
        }

        private void InitializeComponents()
        {
            if (_components == null || _components.Count == 0) return;

            foreach (var component in _components)
            {
                if(component is PlayerMovement) _playerMovement = (PlayerMovement)component;
                if(component is PlayerLook) _playerLook = (PlayerLook)component;
                if(component is PlayerInteractor) _playerInteractor = (PlayerInteractor)component;

                component.Inititalize(_input, _config, _stateMachine);
            }

            _stateMachine.Initialize(this);
        }

        #region State Handling

        public void SetControls(bool movement, bool look, bool interact)
        {
            //Set whatever is allowed
            _playerMovement.enabled = movement;
            _playerLook.enabled = look;
            _playerInteractor.enabled = interact;
        }

        public void EnablePlayerInput() => _inputReader.EnablePlayerInput();
        public void DisablePlayerInput() => _inputReader.DisablePlayerInput();

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
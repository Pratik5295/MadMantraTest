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
        private InputReader _inputReader;
        [SerializeField]
        private PlayerConfig _config;
        private IInputEvents _input => _inputReader;

        private void Awake()
        {
            if (_input == null)
                Debug.LogError("Missing Input Reader");

            InitializeComponents();

        }

        private void Start()
        {
            _inputReader.EnablePlayerInput();   //Keeping it active by default for now
        }

        private void OnDestroy()
        {
        }
        private void InitializeComponents()
        {
            if (_components == null || _components.Count == 0) return;

            foreach (var component in _components)
            {
                component.Inititalize(_input, _config);
            }
        }
    }
}
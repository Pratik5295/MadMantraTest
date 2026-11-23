using MMTest.GameEvents;
using MMTest.Input;
using UnityEngine;

namespace MMTest.Gameplay.Player
{
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField]
        private InputReader _inputReader;
        [SerializeField]
        private Transform _playerRoot;
        [SerializeField]
        private Transform _viewPivot;

        private Vector2 _lookInput;
        private float _yaw, _pitch;

        private IInputEvents _input => _inputReader;

        private void Awake()
        {
            if (_input == null)
                Debug.LogError("Missing Input Reader");

        }

        private void OnEnable()
        {
            _input.Look += OnLook;
        }

        private void LateUpdate()
        {
            Look();
        }

        private void OnDisable()
        {
            _input.Look -= OnLook;
        }

        private void OnLook(Vector2 look)
        {
            _lookInput = look;
        }

        private void Look()
        {
            _yaw += _lookInput.x;
            _pitch += _lookInput.y;

            _pitch = Mathf.Clamp(_pitch, -80f, 80f);

            _playerRoot.rotation = Quaternion.Euler(0,_yaw, 0);
            _viewPivot.localRotation = Quaternion.Euler(-_pitch, 0, 0);
        }
    }
}
using MMTest.Data;
using MMTest.GameEvents;
using UnityEngine;

namespace MMTest.Gameplay.Player
{
    [DefaultExecutionOrder(2)]
    public class PlayerLook : PlayerComponent
    {
        [SerializeField]
        private Transform _playerRoot;
        [SerializeField]
        private Transform _viewPivot;

        private Vector2 _lookInput;
        private float _yaw, _pitch;

        private void LateUpdate()
        {
            Look();
        }
        private void OnLook(Vector2 look)
        {
            _lookInput = look;
        }

        private void Look()
        {
            _yaw += _lookInput.x * _config.CameraSensitivity;
            _pitch += _lookInput.y * _config.CameraSensitivity;

            _lookInput = Vector2.zero;

            _pitch = Mathf.Clamp(_pitch, _config.PitchMin, _config.PitchMax);

            _playerRoot.rotation = Quaternion.Euler(0,_yaw, 0);
            _viewPivot.localRotation = Quaternion.Euler(-_pitch, 0, 0);
        }

        protected override void Subscribe()
        {
            _input.Look += OnLook;
        }

        protected override void Unsubscribe()
        {
            _input.Look -= OnLook;
        }

        protected override void ResetInputs()
        {
            _lookInput = Vector2.zero;
        }
    }
}
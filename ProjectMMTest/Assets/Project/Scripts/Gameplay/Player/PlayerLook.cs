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

        //Dialogue State Vars
        private bool _dialogueMode;
        private float _centYaw, _centPitch;
        private float _offYaw, _offPitch;   

        private void LateUpdate()
        {
            Look();
        }
        private void OnLook(Vector2 look)
        {
            _lookInput += look;
        }

        public void SetConstraints(Vector3 target)
        {
            Quaternion facing = Quaternion.LookRotation(target - _viewPivot.position).normalized;
            Vector3 angles = facing.eulerAngles;

            _centYaw = angles.y;
            _centPitch = -Mathf.DeltaAngle(0, angles.x);

            _offYaw = 0;
            _offPitch = 0;
            _dialogueMode = true;
        }

        public void ResetDialogueMode()
        {
            _dialogueMode = false;
        }

        private void Look()
        {
            Vector2 delta = _lookInput * _config.CameraSensitivity;

            _lookInput = Vector2.zero;

            //_pitch = Mathf.Clamp(_pitch, _config.PitchMin, _config.PitchMax);

            if (_dialogueMode)
            {
                DialogueLook(delta);
            }
            else
            {
                FreeLook(delta);
            }

               _playerRoot.rotation = Quaternion.Euler(0, _yaw, 0);
            _viewPivot.localRotation = Quaternion.Euler(-_pitch, 0, 0);
        }

        private void FreeLook(Vector2 delta)
        {
            _yaw += delta.x;
            _pitch = Mathf.Clamp(_pitch + delta.y, _config.PitchMin, _config.PitchMax);
        }

        private void DialogueLook(Vector2 delta)
        {
            if(delta != Vector2.zero)
            {
                _offYaw += delta.x;
                _offPitch += delta.y;
            }
            _offYaw = Mathf.Clamp(_offYaw, -_config.DialogueYawLimit, _config.DialogueYawLimit);
            _offPitch = Mathf.Clamp(_offPitch, -_config.DialoguePitchLimit, _config.DialoguePitchLimit);

            _yaw = _centYaw + _offYaw;
            _pitch = _centPitch + _offPitch;

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
using MMTest.Data;
using MMTest.GameEvents;
using UnityEngine;

namespace MMTest.Gameplay.Player
{
    [RequireComponent(typeof(CharacterController)), DefaultExecutionOrder(2)]
    public class PlayerMovement : PlayerComponent
    {
        private CharacterController _characterController;

        private float _currentMoveSpeed = 0;
        private Vector2 _moveInput;
        private bool _isSprinting = false;
        private Vector3 velocity = Vector3.zero;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            _currentMoveSpeed = _config.BaseMoveSpeed;
        }

        private void Update()
        {
            Movement();
        }

        protected override void Subscribe()
        {
            _input.Move += OnMove;
            _input.Sprint += OnSprint;
        }

        protected override void Unsubscribe()
        {
            _input.Move -= OnMove;
            _input.Sprint -= OnSprint;
        }

        protected override void ResetInputs()
        {
            _moveInput = Vector2.zero;
            _isSprinting = false;
        }

        #region Input Event Handlers

        private void OnMove(Vector2 move)
        {
            _moveInput = move;
        }

        private void OnSprint(bool sprint)
        {
            _isSprinting = sprint;
        }

        #endregion

        private void Movement()
        {
            _currentMoveSpeed = _isSprinting ? _config.SprintSpeed : _config.BaseMoveSpeed;

            Vector3 direction = transform.right * _moveInput.x + transform.forward * _moveInput.y;

            direction = Vector3.ClampMagnitude(direction, 1);

            velocity = direction * _currentMoveSpeed;
            _characterController.Move(velocity * Time.deltaTime);
        }

    }
}
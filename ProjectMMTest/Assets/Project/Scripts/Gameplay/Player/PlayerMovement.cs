using MMTest.GameEvents;
using MMTest.Input;
using UnityEngine;

namespace MMTest.Gameplay.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private InputReader _inputReader;
        [SerializeField]
        private float _moveSpeed;
        [SerializeField]
        private float _sprintSpeed;

        private CharacterController _characterController;

        private float _currentMoveSpeed = 0;
        private Vector2 _moveInput;
        private bool _isSprinting = false;
        private Vector3 velocity = Vector3.zero;

        private IInputEvents _input => _inputReader;


        private void Awake()
        {
            if(_input == null)
                Debug.LogError("Missing Input Reader");

            _characterController = GetComponent<CharacterController>();

        }

        private void OnEnable()
        {
            _input.Move += OnMove;
            _input.Sprint += OnSprint;
        }

        private void Start()
        {
            _inputReader.EnablePlayerInput();   //Keeping it active by default for now
            _currentMoveSpeed = _moveSpeed;
        }

        private void Update()
        {
            Movement();
        }

        private void OnDisable()
        {
            _input.Move -= OnMove;
            _input.Sprint -= OnSprint;

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
            _currentMoveSpeed = _isSprinting ? _sprintSpeed : _moveSpeed;

            Vector3 direction = transform.right * _moveInput.x + transform.forward * _moveInput.y;

            direction = Vector3.ClampMagnitude(direction, 1);

            velocity = direction * _currentMoveSpeed;
            _characterController.Move(velocity * Time.deltaTime);
        }

    }
}
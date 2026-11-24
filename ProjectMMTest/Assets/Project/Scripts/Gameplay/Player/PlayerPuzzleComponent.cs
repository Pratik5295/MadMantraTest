using MMTest.GameEvents;
using UnityEngine;
using static UnityEditor.PlayerSettings;

namespace MMTest.Gameplay.Player
{
    public class PlayerPuzzleComponent : PlayerComponent
    {
        [SerializeField]
        private Camera _camera;

        private Vector2 _pos;
        private Ray _ray;

        private GameObject _focused; //Puzzle button focused

        protected override void Subscribe()
        {
            _input.Back += OnBack;
            _input.Point += OnPoint;
            _input.Click += OnPuzzleClick;
        }
        protected override void Unsubscribe()
        {
            _input.Back -= OnBack;
            _input.Point -= OnPoint;
            _input.Click -= OnPuzzleClick;
        }

        private void OnBack()
        {
            _stateMachine.SwitchToGameplay();
        }

        private void OnPoint(Vector2 pos)
        {
            _pos = pos;
            GamePlayEvents.BroadcastPuzzleMousePos(pos);
        }

        private void OnPuzzleClick()
        {
            Debug.Log($"Clicked when: {_pos.x} and {_pos.y}");
        }

        private void Update()
        {
            _ray = _camera.ScreenPointToRay(_pos);
            CheckForPuzzleElement();
        }

        private void CheckForPuzzleElement()
        {
            if(Physics.Raycast(_ray,out RaycastHit hit, _config.InteractRange, _config.PuzzleElementLayer))
            {
               
            }
        }
    }
}
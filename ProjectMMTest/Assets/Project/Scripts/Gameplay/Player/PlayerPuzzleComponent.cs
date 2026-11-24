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

        private IPuzzleElement _focused; //Puzzle button focused

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
            if (_focused != null) _focused.Interact();
        }

        private void Update()
        {
            _ray = _camera.ScreenPointToRay(_pos);
            CheckForPuzzleElement();
        }

        private void CheckForPuzzleElement()
        {
            IPuzzleElement element = null;
            if(Physics.Raycast(_ray,out RaycastHit hit, _config.InteractRange, _config.PuzzleElementLayer))
            {
                element = hit.collider.GetComponentInParent<IPuzzleElement>();
            }
            if(element != _focused)
            {
                _focused = element;
            }
        }
    }
}
using UnityEngine;

namespace MMTest.Gameplay.Player
{
    public class PlayerPuzzleComponent : PlayerComponent
    {
        [SerializeField]
        private Camera _camera;

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
            _ray = _camera.ScreenPointToRay(pos);
        }

        private void OnPuzzleClick()
        {

        }

        private void Update()
        {
            CheckForPuzzleElement();
        }

        private void CheckForPuzzleElement()
        {
            if(Physics.SphereCast(_ray,_config.InteractRadius,out RaycastHit hit, _config.InteractRange, _config.PuzzleElementLayer))
            {
                Debug.Log("Hitting a puzzle element");
            }
        }
    }
}
using UnityEngine;

namespace MMTest.Gameplay.Player
{
    public class PlayerInteractor : PlayerComponent
    {
        [SerializeField]
        private Transform _camera;

        [SerializeField] private GameObject _focused;

        protected override void Subscribe()
        {
            _input.Interact += OnInteract;
        }

        protected override void Unsubscribe()
        {
            _input.Interact -= OnInteract;
        }

        private void OnInteract()
        {

        }

        private void Update()
        {
            CheckForInteractable();
        }

        private void CheckForInteractable()
        {
            if(Physics.Raycast(_camera.position, _camera.forward, out RaycastHit hit, Mathf.Infinity))
            {
                if (hit.collider)
                {
                    _focused = hit.collider.gameObject;
                }
            }
        }
    }
}
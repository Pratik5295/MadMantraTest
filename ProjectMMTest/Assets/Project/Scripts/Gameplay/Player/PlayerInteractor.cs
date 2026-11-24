using UnityEngine;

namespace MMTest.Gameplay.Player
{
    public class PlayerInteractor : PlayerComponent
    {
        [SerializeField]
        private Transform _camera;

        private IInteractable _focused;

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
            if(_focused != null)
            {
                _focused.Interact();
            }
        }

        private void Update()
        {
            CheckForInteractable();
        }

        private void CheckForInteractable()
        {
            IInteractable found = null;

            if(Physics.SphereCast(_camera.position,_config.InteractRadius, _camera.forward, out RaycastHit hit, _config.InteractRange, _config.InteractLayer))
            {
                found = hit.collider.GetComponentInParent<IInteractable>();
            }
            if(found != _focused)
            {
                _focused = found;
            }
        }


        //Debugs
        private void OnDrawGizmosSelected()
        {
            if (!Application.isPlaying) return;

            if (_focused != null)
            {
                Gizmos.color = Color.green;
            }
            else
            {
                Gizmos.color = Color.red;
            }

            Gizmos.DrawRay(_camera.position,_camera.forward * _config.InteractRange);
        }
    }
}
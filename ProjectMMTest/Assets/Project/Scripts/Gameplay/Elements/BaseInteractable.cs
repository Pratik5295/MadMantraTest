using MMTest.Gameplay.Player;
using UnityEngine;

namespace MMTest.Gameplay
{
    public abstract class BaseInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private string _message;

        [SerializeField]
        private BaseTriggerable _trigger;

        protected bool _withinRange = false;

        protected GameObject _playerRef = null;

        public string Message => _message;
        public BaseTriggerable Trigger => _trigger;
        public bool WithinRange => _withinRange;

        public abstract void Interact(PlayerInteractor interactor);

        public virtual void OnEnable()
        {
            _trigger.OnPlayerEnter += OnPlayerEnter;
            _trigger.OnPlayerExit += OnPlayerExit;
        }

        public virtual void OnDisable()
        {
            _trigger.OnPlayerEnter -= OnPlayerEnter;
            _trigger.OnPlayerExit -= OnPlayerExit;
        }

        protected virtual void OnPlayerEnter(GameObject player)
        {
            _withinRange = true;
            _playerRef = player;
        }

        protected virtual void OnPlayerExit()
        {
            _withinRange = false;
            _playerRef = null;
        }
    }
}
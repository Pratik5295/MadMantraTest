using UnityEngine;

namespace MMTest.Gameplay
{
    public abstract class BaseInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private string _message;

        public string Message => _message;

        public abstract void Interact();
    }
}
using UnityEngine;

namespace MMTest.Gameplay
{
    public class BaseInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private string _message;

        public string Message => _message;

        public void Interact()
        {
            Debug.Log($"Interacted with: {gameObject.name}");
        }
    }
}
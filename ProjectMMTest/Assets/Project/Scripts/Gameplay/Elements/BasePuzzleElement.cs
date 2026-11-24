using UnityEngine;
using UnityEngine.Events;

namespace MMTest.Gameplay
{
    public class BasePuzzleElement : MonoBehaviour, IPuzzleElement
    {
        [SerializeField]
        protected bool _multipleInteractions = false; //Can it be interacted with more than once?

        private bool _isInteractedWith = false;

        [SerializeField]
        private UnityEvent OnInteracted; //Setup in engine
        public virtual void Interact()
        {
            if (_isInteractedWith && _multipleInteractions) return; 

            Debug.Log($"Interacted with: {name}");

            if (!_multipleInteractions)
            {
                _isInteractedWith = true;
            }

            OnInteracted?.Invoke();
        }
    }
}
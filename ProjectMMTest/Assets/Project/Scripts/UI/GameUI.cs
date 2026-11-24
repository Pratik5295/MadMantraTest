using MMTest.GameEvents;
using MMTest.Gameplay;
using UnityEngine;

namespace MMTest.UI
{
    public class GameUI:MonoBehaviour
    {
        //Press E to interact UI
        [SerializeField] private GameObject _interactUI;

        [SerializeField] private Transform _cursor;

        private void OnEnable()
        {
            GameplayEvents.OnFocusedChanged += OnFocusInteractableChanged;
        }

        private void Start()
        {
            _interactUI.SetActive(false);
        }

        private void OnDisable()
        {
            GameplayEvents.OnFocusedChanged -= OnFocusInteractableChanged;
        }

        #region Interaction Section
        private void OnFocusInteractableChanged(IInteractable interactable)
        {
            bool show = interactable == null ? false : true;

            _interactUI.SetActive(show);
        }
        #endregion
    }
}
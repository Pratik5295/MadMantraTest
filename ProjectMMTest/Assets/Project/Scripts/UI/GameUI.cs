using MMTest.GameEvents;
using MMTest.Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MMTest.UI
{
    public class GameUI:MonoBehaviour
    {
        //Press E to interact UI
        [SerializeField] private GameObject _interactUI;

        [SerializeField] private RectTransform _cursor;

        private void OnEnable()
        {
            GameEvents.GamePlayEvents.OnFocusedChanged += OnFocusInteractableChanged;
            GameEvents.GamePlayEvents.OnPuzzleLookInput += OnPuzzleCursorHandling;
            GameEvents.GamePlayEvents.OnGameStateChanged += OnGameStateChanged;
        }

        private void Start()
        {
            _interactUI.SetActive(false);
        }


        private void OnDisable()
        {
            GameEvents.GamePlayEvents.OnFocusedChanged -= OnFocusInteractableChanged;
            GameEvents.GamePlayEvents.OnPuzzleLookInput -= OnPuzzleCursorHandling;
            GameEvents.GamePlayEvents.OnGameStateChanged -= OnGameStateChanged;
        }

        #region Interaction Section
        private void OnFocusInteractableChanged(IInteractable interactable)
        {
            bool show = interactable == null ? false : true;

            _interactUI.SetActive(show);
        }
        #endregion

        private void OnPuzzleCursorHandling(Vector2 pos)
        {
            if(RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)_cursor.parent, pos, null, out Vector2 localposition))
            {
                _cursor.localPosition = new Vector3(localposition.x, localposition.y, 0);
            }
        }

        private void OnGameStateChanged(GameState state)
        {
            //Reset cursor position
            _cursor.localPosition = Vector3.zero;

            if (state is not GameplayState) _interactUI.SetActive(false); 
        }
    }
}
using MMTest.GameEvents;
using MMTest.Gameplay;
using TMPro;
using UnityEngine;

namespace MMTest.UI
{
    public class GameUI:MonoBehaviour
    {
        //Press E to interact UI
        [SerializeField] private GameObject _interactUI;

        [SerializeField] private GameObject _toasterUI;
        [SerializeField] private TextMeshProUGUI _toasterMessage;

        [SerializeField] private RectTransform _cursor;

        private void OnEnable()
        {
            GamePlayEvents.OnFocusedChanged += OnFocusInteractableChanged;
            GamePlayEvents.OnPuzzleLookInput += OnPuzzleCursorHandling;
            GamePlayEvents.OnGameStateChanged += OnGameStateChanged;
            GamePlayEvents.OnShowToasterMessage += SetToasterMessage;
        }

        private void Start()
        {
            _interactUI.SetActive(false);
            HideToaster();
        }


        private void OnDisable()
        {
            GamePlayEvents.OnFocusedChanged -= OnFocusInteractableChanged;
            GamePlayEvents.OnPuzzleLookInput -= OnPuzzleCursorHandling;
            GamePlayEvents.OnGameStateChanged -= OnGameStateChanged;
            GamePlayEvents.OnShowToasterMessage -= SetToasterMessage;
        }

        #region Interaction Section
        private void OnFocusInteractableChanged(IInteractable interactable)
        {
            bool show = interactable == null ? false : true;

            _interactUI.SetActive(show);
        }
        #endregion

        #region Toaster Section

        private void ShowToaster()
        {
            _toasterUI.SetActive(true);
        }

        private void HideToaster()
        {
            _toasterUI.SetActive(false);
        }

        private void SetToasterMessage(string message)
        {
            _toasterMessage.text = message;

            ShowToaster();

            Invoke(nameof(HideToaster), 2f);
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
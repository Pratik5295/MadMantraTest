using MMTest.Data;
using MMTest.Managers;
using TMPro;
using UnityEngine;

namespace MMTest.UI
{
    [DefaultExecutionOrder(10)]
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private TextMeshProUGUI _messageText;   //Where message will be shown

        private int _index = 0; //Counter to keep incrementing for no of messages

        private void OnEnable()
        {
            DialogueManager.Instance.OnDialogueStart += OnDialogueStart;
        }

        private void Start()
        {
            HideUI();
        }

        private void OnDisable()
        {
            DialogueManager.Instance.OnDialogueStart -= OnDialogueStart;
        }

        private void OnDialogueStart(DialogueSO dialogue)
        {
            var Lines = dialogue.Lines;

            ShowLine(Lines[0].text);
            ShowUI();
        }

        private void ShowUI()
        {
            _canvasGroup.alpha = 1.0f;
        }

        private void HideUI()
        {
            _canvasGroup.alpha = 0.0f;
        }

        private void ShowLine(string line)
        {
            _messageText.text = line;
        }
    }
}
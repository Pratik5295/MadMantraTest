using MMTest.Data;
using MMTest.Managers;
using System.Collections;
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

        private float _delayBetweenCharacters;
        private Coroutine _typingCoroutine;
        private bool _isTyping = false;
        private string _messageToShow;
        private DialogueSO _dialogue;

        private void OnEnable()
        {
            DialogueManager.Instance.OnDialogueStart += OnDialogueStart;
        }

        private void Start()
        {
            HideUI();
            _delayBetweenCharacters = (float)DialogueManager.Instance.GetSettingsConfig?.Invoke().TypingDelayBetweenCharacters;
        }

        private void OnDisable()
        {
            DialogueManager.Instance.OnDialogueStart -= OnDialogueStart;
        }

        private void OnDialogueStart(DialogueSO dialogue)
        {
            _dialogue = dialogue;
            var Lines = _dialogue.Lines;

            _index = 0;
            _messageToShow = Lines[_index].text;
            ShowUI();

            _typingCoroutine = StartCoroutine(StartTypingCoroutine(_messageToShow));
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

        private IEnumerator StartTypingCoroutine(string message)
        {
            _messageText.text = message;

            _messageText.maxVisibleCharacters = 0;
            _isTyping = true;

            int totalCharCount = _messageText.textInfo.characterCount;

            _messageText.ForceMeshUpdate();

            for (int i = 0; i <= totalCharCount; i++)
            {
                _messageText.maxVisibleCharacters = i;
                yield return new WaitForSeconds(_delayBetweenCharacters);
            }

            _isTyping = false;
            _typingCoroutine = null;
        }

        public void OnNextInput()
        {
            if (_isTyping)
            {
                StopCoroutine(_typingCoroutine);
                _isTyping = false;
                _typingCoroutine = null;
                _messageText.text = _messageToShow;
            }

            _index++;
            _messageToShow = _dialogue.Lines[_index].text;
            _typingCoroutine = StartCoroutine(StartTypingCoroutine(_messageToShow));
        }
    }
}
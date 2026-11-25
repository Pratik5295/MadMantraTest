using MMTest.Data;
using MMTest.UI;
using System;
using UnityEngine;

namespace MMTest.Managers
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { get; private set; }

        [SerializeField]
        private SettingsConfig _settingsConfig; // TODO:Move to game Manager separately

        [SerializeField]
        private DialogueUI _dialogueUI;

        public Func<SettingsConfig> GetSettingsConfig;
        public Action<DialogueSO> OnDialogueStart;

        private void Awake()
        {
            if(Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            GetSettingsConfig += () => _settingsConfig;
        }

        private void OnDestroy()
        {
            GetSettingsConfig -= () => _settingsConfig;
        }

        public void SetDialogue(DialogueSO dialogue)
        {
            OnDialogueStart?.Invoke(dialogue);
        }

        public void OnDialogueNext()
        {
            if(_dialogueUI == null)
            {
                Debug.LogError("Missing Dialogue UI component");
                return;
            }

            _dialogueUI.OnNextInput();
        }
    }
}
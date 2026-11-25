using MMTest.Data;
using System;
using UnityEngine;

namespace MMTest.Managers
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { get; private set; }

        [SerializeField]
        private SettingsConfig _settingsConfig; // TODO:Move to game Manager separately

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

        public void SetDialogue(DialogueSO dialogue)
        {
            OnDialogueStart?.Invoke(dialogue);
        }
    }
}
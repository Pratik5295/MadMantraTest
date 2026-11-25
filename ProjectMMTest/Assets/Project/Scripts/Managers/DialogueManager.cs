using MMTest.Data;
using MMTest.GameEvents;
using System;
using UnityEngine;

namespace MMTest.Managers
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { get; private set; }

        [SerializeField]
        private SettingsConfig _settingsConfig; // TODO:Move to game Manager separately

        public Func<SettingsConfig> GetSettingsConfig;

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
            GamePlayEvents.RaiseDialogueStarted(dialogue);
        }

        public void OnDialogueNext()
        {
           GamePlayEvents.RaiseDialogueNext();
        }

        public void OnDialogueEnd()
        {
            GamePlayEvents.RaiseDialogueEnded();
        }
    }
}
using UnityEngine;

namespace MMTest.Data
{
    [CreateAssetMenu(fileName = "SettingsConfig", menuName = "Project/Data/Create a Settings Config")]
    public class SettingsConfig: ScriptableObject
    {
        [SerializeField]
        private float _dialogueCharPerSecond = 10f;

        public float DialogueCharPerSec => _dialogueCharPerSecond;
    }
}
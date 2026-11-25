using UnityEngine;

namespace MMTest.Data
{
    [CreateAssetMenu(fileName = "SettingsConfig", menuName = "Project/Data/Create a Settings Config")]
    public class SettingsConfig: ScriptableObject
    {
        [SerializeField]
        private float _delayBetweenCharacters = 0.05f;

        public float TypingDelayBetweenCharacters => _delayBetweenCharacters;
    }
}
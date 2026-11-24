using System.Collections.Generic;
using UnityEngine;

namespace MMTest.Data
{
    [System.Serializable]
    public struct DialogueLine
    {
        public string text;

    }

    [CreateAssetMenu(fileName = "DialogueSO", menuName = "Project/Data/Create a Dialogue File")]
    public class DialogueSO : ScriptableObject
    {
        [SerializeField]
        private DialogueLine[] _lines;

        public IReadOnlyList<DialogueLine> Lines => _lines;
    }
}
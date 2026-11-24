using UnityEngine;

namespace MMTest.Data
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Project/Data/Player/Create Player Config")]
    public class PlayerConfig: ScriptableObject
    {
        [Header("Movement")]
        [SerializeField]
        private float _baseMoveSpeed;
        public float BaseMoveSpeed => _baseMoveSpeed;
        [SerializeField]
        private float _sprintSpeed;
        public float SprintSpeed => _sprintSpeed;

        [Space(5), Header("Look")]
        [SerializeField]
        private float _cameraSensitivity;
        public float CameraSensitivity => _cameraSensitivity;
        [SerializeField]
        private float _pitchMin;
        public float PitchMin => _pitchMin;
        [SerializeField]
        private float _pitchMax;
        public float PitchMax => _pitchMax;

        [Space(5), Header("Interact")]
        [SerializeField]
        private LayerMask _interactLayer;
        public LayerMask InteractLayer => _interactLayer;
        [SerializeField]
        private float _interactionRange;
        public float InteractRange => _interactionRange;
        [SerializeField, Tooltip("How big the interaction ray radius is")]
        private float _interactionRadius;
        public float InteractRadius => _interactionRadius;

        //Puzzle Settings
        [Space(5), Header("Puzzle Settings")]
        [SerializeField]
        private LayerMask _puzzleElementLayer;
        public LayerMask PuzzleElementLayer => _puzzleElementLayer;
    }
}
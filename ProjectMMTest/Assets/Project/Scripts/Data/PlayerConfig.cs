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

        [Space(5),Header("Look")]
        [SerializeField]
        private float _pitchMin;
        public float PitchMin => _pitchMin;
        [SerializeField]
        private float _pitchMax;
        public float PitchMax => _pitchMax;
    }
}
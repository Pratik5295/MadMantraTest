using UnityEngine;

namespace MMTest.Gameplay
{
    [RequireComponent(typeof(Animator))]
    public class NPCAnimController : MonoBehaviour
    {
        private Animator _animator;
        private float _moveValue;

        private static readonly int _moveParam = Animator.StringToHash("Move");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void StartWalk()
        {
            _moveValue = 1;
            UpdateAnimator();
        }

        public void StopWalk()
        {
            _moveValue = 0;
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            _animator.SetFloat(_moveParam, _moveValue);
        }
    }
}
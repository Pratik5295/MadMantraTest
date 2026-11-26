using UnityEngine;

namespace MMTest.Gameplay
{
    [RequireComponent(typeof(Animator))]
    public class NPCHeadTracker : MonoBehaviour
    {
        private Animator _animator;
        [SerializeField]
        private float _maxAngle = 60f;

        private Transform _target;
        private bool IsTracking = false;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            IsTracking = target != null ? true : false;
        }

        private void OnAnimatorIK(int layerIndex)
        {
            if (!IsTracking || _target == null) return;  

            Vector3 headBone = _animator.GetBoneTransform(HumanBodyBones.Head).position;

            Vector3 direction = Vector3.RotateTowards(transform.forward, _target.position - headBone, _maxAngle * Mathf.Deg2Rad, 0f);

            _animator.SetLookAtWeight(IsTracking ? 1f : 0);
            _animator.SetLookAtPosition(headBone + direction);
        }

    }
}
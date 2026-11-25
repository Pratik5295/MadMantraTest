using System.Collections;
using UnityEngine;

namespace MMTest.Gameplay
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Transform _pivot;
        [SerializeField] private float _openAngle = 90f;
        [SerializeField] private float _duration = 3f;

        private Quaternion _closedRotation;
        private Coroutine _doorRoutine;

        private bool _isOpen = false;
        private bool _isLocked = false;

        public bool IsOpen => _isOpen;
        public bool IsLocked => _isLocked;

        private void Awake()
        {
            _closedRotation = _pivot.localRotation;
        }

        public void Unlock() => _isLocked = false;
        public void OpenWithPlayer(Vector3 playerPosition)
        {
            if (_isLocked) return;

            Vector3 direction = playerPosition - _pivot.position;
            float dot = Vector3.Dot(transform.forward, direction);

            if (dot >= 0f)
                dot = _openAngle;
            else
                dot = -_openAngle;

            RotateTo(_closedRotation * Quaternion.Euler(0,dot, 0));
            _isOpen = true;
        }

        public void Close()
        {
            RotateTo(_closedRotation);
            _isOpen = false;
        }
        private void RotateTo(Quaternion target)
        {
            if(_doorRoutine != null) StopCoroutine(_doorRoutine);

            _doorRoutine = StartCoroutine(RotateCoroutine(target));
        }

        private IEnumerator RotateCoroutine(Quaternion target)
        {
            Quaternion start = _pivot.localRotation;

            for(float t = 0f; t < 1f; t+= Time.deltaTime / _duration)
            {
                _pivot.localRotation = Quaternion.Slerp(start, target, t);
                yield return null;
            }

            _pivot.localRotation = target;
            _doorRoutine = null;
        }
    }
}
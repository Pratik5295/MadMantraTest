using System.Collections;
using UnityEngine;

namespace MMTest.Gameplay.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField]
        private Transform _camera;

        [SerializeField] private float _focusDuration = 0.5f; //TODO: Setup via Player Component and config setup
        private Coroutine _cameraRoutine;


        private Vector3 _cameraRestPos;
        private Quaternion _cameraRestRot;

        private void Start()
        {
            _cameraRestPos = _camera.localPosition;
            _cameraRestRot = _camera.localRotation;
        }

        public void FocusCamera(Transform focusPoint)
            => MoveCamera(focusPoint.position, focusPoint.rotation, worldSpace: true);

        public void ReleaseCamera()
            => MoveCamera(_cameraRestPos, _cameraRestRot, worldSpace: false);

        private void MoveCamera(Vector3 position, Quaternion rotation, bool worldSpace)
        {
            if (_cameraRoutine != null) StopCoroutine(_cameraRoutine);
            _cameraRoutine = StartCoroutine(MoveCameraRoutine(position, rotation, worldSpace));
        }

        private IEnumerator MoveCameraRoutine(Vector3 targetPos, Quaternion targetRot, bool worldSpace)
        {
            Vector3 startPos = worldSpace ? _camera.position : _camera.localPosition;
            Quaternion startRot = worldSpace ? _camera.rotation : _camera.localRotation;

            for (float t = 0f; t < 1f; t += Time.deltaTime / _focusDuration)
            {
                float e = Mathf.SmoothStep(0f, 1f, t);   // ease in and out
                Vector3 pos = Vector3.Lerp(startPos, targetPos, e);
                Quaternion rot = Quaternion.Slerp(startRot, targetRot, e);

                if (worldSpace) _camera.SetPositionAndRotation(pos, rot);
                else _camera.SetLocalPositionAndRotation(pos, rot);

                yield return null;
            }

            if (worldSpace) _camera.SetPositionAndRotation(targetPos, targetRot);
            else _camera.SetLocalPositionAndRotation(targetPos, targetRot);

            _cameraRoutine = null;
        }
    }
}
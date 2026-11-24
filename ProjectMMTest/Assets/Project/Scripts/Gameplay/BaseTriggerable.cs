using System;
using UnityEngine;

namespace MMTest.Gameplay
{
    [RequireComponent(typeof(Collider))]
    public class BaseTriggerable : MonoBehaviour
    {
        public event Action OnPlayerEnter;
        public event Action OnPlayerExit;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(MetaConstants.PlayerTag))
            {
                OnPlayerEnter?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(MetaConstants.PlayerTag))
            {
                OnPlayerExit?.Invoke();
            }
        }
    }
}
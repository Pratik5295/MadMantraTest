using MMTest.Gameplay.Player;
using UnityEngine;
using MMTest.Data;
using MMTest.Managers;
using UnityEngine.Events;
using MMTest.GameEvents;

namespace MMTest.Gameplay
{
    public class PickupInteractable : BaseInteractable
    {
        [SerializeField]
        private bool _canBePicked;

        [SerializeField]
        private PickupItemSO _data;

        public bool CanBePicked => _canBePicked;

        public UnityEvent OnItemPickedUp;

        public void Unlock() { _canBePicked = true; }
        public override void Interact(PlayerInteractor interactor)
        {
            if (!_canBePicked) return;

            gameObject.SetActive(false);

            InventoryManager.Instance?.ItemPickedUp(_data);

            OnItemPickedUp?.Invoke();

            GamePlayEvents.NotifyToasterMessage(Message);
        }
    }
}
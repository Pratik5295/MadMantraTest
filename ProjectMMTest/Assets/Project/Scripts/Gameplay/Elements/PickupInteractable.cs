using MMTest.Gameplay.Player;
using UnityEngine;
using MMTest.Data;
using MMTest.Managers;

namespace MMTest.Gameplay
{
    public class PickupInteractable : BaseInteractable
    {
        [SerializeField]
        private bool _canBePicked;

        [SerializeField]
        private PickupItemSO _data;

        public bool CanBePicked => _canBePicked;

        public void Unlock() { _canBePicked = true; }
        public override void Interact(PlayerInteractor interactor)
        {
            if (!_canBePicked) return;

            gameObject.SetActive(false);

            InventoryManager.Instance?.ItemPickedUp(_data);
        }
    }
}
using MMTest.Gameplay.Player;
using UnityEngine;

namespace MMTest.Gameplay
{

    public class DoorInteractable : BaseInteractable
    {
        [SerializeField] private Door _door;
        public override void Interact(PlayerInteractor interactor)
        {
            if (_door.IsLocked)
            {
                return;
            }

            if (_door.IsOpen) _door.Close();

            else
                _door.OpenWithPlayer(interactor.transform.position);
        }
    }
}
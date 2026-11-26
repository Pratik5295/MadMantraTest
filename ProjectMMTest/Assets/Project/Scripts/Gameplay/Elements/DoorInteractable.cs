using MMTest.GameEvents;
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
                GamePlayEvents.NotifyToasterMessage(Message);
                return;
            }

            if (_door.IsOpen) _door.Close();

            else
                _door.OpenWithPlayer(interactor.transform.position);
        }
    }
}
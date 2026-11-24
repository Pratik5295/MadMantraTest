using MMTest.Gameplay.Player;
using UnityEngine;

namespace MMTest.Gameplay
{
    public class DoorInteractable : BaseInteractable
    {
        public override void Interact(PlayerInteractor interactor)
        {
            Debug.Log(Message);
        }
    }
}
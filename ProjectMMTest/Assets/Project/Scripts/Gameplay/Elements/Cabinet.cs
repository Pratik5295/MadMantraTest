using MMTest.Gameplay.Player;
using UnityEngine;

namespace MMTest.Gameplay
{
    public class Cabinet : BaseInteractable
    {
        public override void Interact(PlayerInteractor interactor)
        {
            Debug.Log(Message);
        }
    }
}
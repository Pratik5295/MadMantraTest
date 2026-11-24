using UnityEngine;

namespace MMTest.Gameplay
{
    public class DoorInteractable : BaseInteractable
    {
        public override void Interact()
        {
            Debug.Log(Message);
        }
    }
}
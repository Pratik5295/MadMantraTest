using MMTest.Data;
using MMTest.Gameplay.Player;
using MMTest.Managers;
using UnityEngine;

namespace MMTest.Gameplay
{
    public class NPCInteractable : BaseInteractable
    {
        [SerializeField]
        private DialogueSO _dialogue;

        [SerializeField]
        private Transform _npc;

        public override void Interact(PlayerInteractor interactor)
        {
            //Start dialogue
            DialogueManager.Instance.SetDialogue(_dialogue);

            interactor.StateMachine.SwitchToDialogueMode(_npc);
        }
    }
}
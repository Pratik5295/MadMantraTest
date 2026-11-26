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
        private Transform _headTransform;

        [SerializeField]
        private NPCHeadTracker _headTracker;

        [SerializeField]
        private Transform _focusPoint; //Focus for dialgoue

        public Transform FocusPoint => _focusPoint;
        public Transform Head => _headTransform;

        public override void Interact(PlayerInteractor interactor)
        {
            //Start dialogue
            DialogueManager.Instance.SetDialogue(_dialogue);

            interactor.StateMachine.SwitchToDialogueMode(this);
        }

        protected override void OnPlayerEnter(GameObject player)
        {
            base.OnPlayerEnter(player);
            _headTracker.SetTarget(player.transform);
        }

        protected override void OnPlayerExit()
        {
            base.OnPlayerExit();
            _headTracker.SetTarget(null);
        }
    }
}
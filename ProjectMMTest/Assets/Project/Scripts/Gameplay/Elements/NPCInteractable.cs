using MMTest.Data;
using MMTest.GameEvents;
using MMTest.Gameplay.Player;
using MMTest.Managers;
using MMTest.Mangaers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

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
        private NPCAnimController _npcAnimController;

        [SerializeField]
        private Transform _focusPoint; //Focus for dialgoue

        [SerializeField]
        private PlayableDirector _director;

        private PlayerInteractor _interactor;

        public Transform FocusPoint => _focusPoint;
        public Transform Head => _headTransform;

        public UnityEvent OnConversationComplete;

        public override void OnEnable()
        {
            base.OnEnable();
            GamePlayEvents.OnDialogueEnded += OnDialogueEnded; //Special case, TODO: Handle properly
        }

        public override void OnDisable()
        {
            base.OnDisable();
            GamePlayEvents.OnDialogueEnded -= OnDialogueEnded;
        }

        public override void Interact(PlayerInteractor interactor)
        {
            _interactor = interactor;
            //Start dialogue
            DialogueManager.Instance.SetDialogue(_dialogue);

            _interactor.StateMachine.SwitchToDialogueMode(this);

            _npcAnimController.StartTalking();
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

        private void OnDialogueEnded()
        {
            _npcAnimController.StopTalking();

            _interactor.StateMachine.SwitchToCinematicMode();

            CinematicManager.Instance.StartCinematic(_director, GameEnd);
        }

        private void GameEnd()
        {
            //TODO: If Game Manager move it there
            Debug.Log("Game ended");

            GamePlayEvents.NotifyGameEnd();
        }
    }
}
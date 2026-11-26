using MMTest.GameEvents;
using MMTest.Managers;

namespace MMTest.Gameplay.Player
{
    public class PlayerDialogueComponent: PlayerComponent
    {
        protected override void Subscribe()
        {
            _input.Interact += OnInteract;
        }

        protected override void Unsubscribe()
        {
            _input.Interact -= OnInteract;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            GamePlayEvents.OnDialogueEnded += OnDialogueEnded;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            GamePlayEvents.OnDialogueEnded -= OnDialogueEnded;
        }

        private void OnInteract()
        {
            //Dialogue Next Command
            DialogueManager.Instance.OnDialogueNext();
        }

        private void OnDialogueEnded()
        {
            //_stateMachine.SwitchToGameplay();
        }
    }
}
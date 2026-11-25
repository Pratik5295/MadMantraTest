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

        private void OnInteract()
        {
            //Dialogue Next Command
            DialogueManager.Instance.OnDialogueNext();
        }
    }
}
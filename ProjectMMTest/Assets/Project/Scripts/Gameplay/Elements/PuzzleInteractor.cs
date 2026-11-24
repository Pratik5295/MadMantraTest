using MMTest.Gameplay.Player;

namespace MMTest.Gameplay
{
    public class PuzzleInteractor : BaseInteractable
    {
        public override void Interact(PlayerInteractor interactor)
        {
            interactor.StateMachine.ChangeMode(new PuzzleState());
        }
    }
}
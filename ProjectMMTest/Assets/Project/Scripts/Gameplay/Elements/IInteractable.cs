
using MMTest.Gameplay.Player;

namespace MMTest.Gameplay
{
    public interface IInteractable
    {
        bool WithinRange { get; }
        string Message { get; } //Triggered when interacted? For example: This is a door, TODO: Toaster UI to show this message
        void Interact(PlayerInteractor interactor);
    }
}
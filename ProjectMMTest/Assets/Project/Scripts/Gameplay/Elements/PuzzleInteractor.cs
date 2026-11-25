using MMTest.Gameplay.Player;
using UnityEngine;

namespace MMTest.Gameplay
{
    public class PuzzleInteractor : BaseInteractable
    {
        [SerializeField] private Transform _focusPoint;

        public Transform FocusPoint => _focusPoint;
        public override void Interact(PlayerInteractor interactor)
        {
            interactor.StateMachine.SwitchToPuzzleMode(this);
        }
    }
}
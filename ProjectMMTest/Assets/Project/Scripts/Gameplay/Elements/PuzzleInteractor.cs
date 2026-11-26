using MMTest.Gameplay.Player;
using UnityEngine;
using System.Collections.Generic;

namespace MMTest.Gameplay
{
    public class PuzzleInteractor : BaseInteractable
    {
        [SerializeField] private Transform _focusPoint;

        [SerializeField]
        private List<BasePuzzleElement> _buttons;

        private int _solvedCount = 0;

        public Transform FocusPoint => _focusPoint;

        public override void Interact(PlayerInteractor interactor)
        {
            interactor.StateMachine.SwitchToPuzzleMode(this);
        }

        public void SubscribeListeners()
        {
            foreach (var button in _buttons)
            {
                button.OnStateChange += OnButtonPressed;
            }
        }

        public void UnsubscribeListeners()
        {
            foreach (var button in _buttons)
            {
                button.OnStateChange -= OnButtonPressed;
            }
        }

        private void OnButtonPressed(bool state)
        {
            if (state)
            {
                _solvedCount++;
            }
            else
            {
                _solvedCount--;
            }

            if(_solvedCount == _buttons.Count)
            {
                //Puzzle solved
                Debug.Log("Puzzle solved, exiting now");
            }
        }
    }
}
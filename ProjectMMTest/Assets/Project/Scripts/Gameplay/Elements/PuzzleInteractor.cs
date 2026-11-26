using MMTest.Gameplay.Player;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Playables;
using MMTest.Mangaers;
using UnityEngine.Events;

namespace MMTest.Gameplay
{
    public class PuzzleInteractor : BaseInteractable
    {
        [SerializeField] private Transform _focusPoint;

        [SerializeField] private Transform _onSolvedLookPoint;

        [SerializeField]
        private List<BasePuzzleElement> _buttons;

        [SerializeField]
        private PlayableDirector _puzzleSolvedCinematic;

        private int _solvedCount = 0;
        private bool _isSolved = false;

        private PlayerInteractor _interactor;

        public Transform FocusPoint => _focusPoint;

        public UnityEvent OnPuzzleSolvedEvent;

        public override void Interact(PlayerInteractor interactor)
        {
            if (_isSolved) return;

            _interactor = interactor;
            _interactor.StateMachine.SwitchToPuzzleMode(this);
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
                OnPuzzleSolved();
            }
        }

        private void OnPuzzleSolved()
        {
            _interactor.StateMachine.SwitchToCinematicMode(_onSolvedLookPoint);

            CinematicManager.Instance.StartCinematic(_puzzleSolvedCinematic, ReturnToGameplay);

            _isSolved = true;

            OnPuzzleSolvedEvent?.Invoke();
        }

        private void ReturnToGameplay()
        {
            _interactor.StateMachine?.SwitchToGameplay();

            _interactor = null;
        }
    }
}
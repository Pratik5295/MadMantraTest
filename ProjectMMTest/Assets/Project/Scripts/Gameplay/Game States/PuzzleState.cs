using MMTest.Gameplay.Player;
using UnityEngine;

namespace MMTest.Gameplay
{
    public class PuzzleState: GameState
    {
        private PuzzleInteractor _puzzle;
        public PuzzleState(PuzzleInteractor puzzle)
        {
            _puzzle = puzzle;
        }

        public override void Enter(GamePlayer player)
        {
            player.SetControls(false, false, false,true,false);
            player.SwitchToPuzzleInput();
            player.FocusCamera(_puzzle.FocusPoint);
        }

        public override void Exit(GamePlayer player)
        {
            player.ReleaseCamera();
        }
    }
}
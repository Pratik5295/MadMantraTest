using MMTest.Gameplay.Player;
using UnityEngine;

namespace MMTest.Gameplay
{
    public class PuzzleState: GameState
    {
        public override void Enter(GamePlayer player)
        {
            Debug.Log("Switching to puzzle state");
            player.SetControls(false, false, false,true);
            player.SwitchToPuzzleInput();
        }
    }
}
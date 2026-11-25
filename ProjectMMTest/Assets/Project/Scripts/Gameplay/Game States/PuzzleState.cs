using MMTest.Gameplay.Player;
using UnityEngine;

namespace MMTest.Gameplay
{
    public class PuzzleState: GameState
    {
        public override void Enter(GamePlayer player)
        {
            player.SetControls(false, false, false,true,false);
            player.SwitchToPuzzleInput();
        }
    }
}
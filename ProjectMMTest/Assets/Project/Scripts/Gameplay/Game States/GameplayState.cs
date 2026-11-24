using MMTest.Gameplay.Player;
using UnityEngine;

namespace MMTest.Gameplay
{
    public class GameplayState : GameState
    {
        public override void Enter(GamePlayer player)
        {
            Debug.Log("Entered Gameplay State");
            player.EnablePlayerInput();
            player.SetControls(true, true, true);
        }
    }
}
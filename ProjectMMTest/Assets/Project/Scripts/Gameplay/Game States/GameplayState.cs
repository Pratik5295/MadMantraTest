using MMTest.Gameplay.Player;
using UnityEngine;

namespace MMTest.Gameplay
{
    public class GameplayState : GameState
    {
        public override void Enter(GamePlayer player)
        {
            player.SwitchToGameplayInput();
            player.SetControls(true, true, true,false);
        }
    }
}
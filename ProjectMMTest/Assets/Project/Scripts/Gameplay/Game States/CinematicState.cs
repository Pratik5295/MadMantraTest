using MMTest.Gameplay.Player;

namespace MMTest.Gameplay
{
    public class CinematicState : GameState
    {
        public override void Enter(GamePlayer player)
        {
            player.SetControls(false, false, false, false, false);
        }
    }
}
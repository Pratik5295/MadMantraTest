using MMTest.Gameplay.Player;

namespace MMTest.Gameplay
{
    public class DialogueState : GameState
    {
        public override void Enter(GamePlayer player)
        {
            player.SetControls(false, true, false, false, true);
        }
    }
}
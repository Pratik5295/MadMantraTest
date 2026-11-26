using MMTest.Gameplay.Player;
using UnityEngine;

namespace MMTest.Gameplay
{
    public class CinematicState : GameState
    {
        private Transform _lookAt;
        public CinematicState(Transform lookAt)
        {
            _lookAt = lookAt;
        }
        public override void Enter(GamePlayer player)
        {
            player.SetControls(false, false, false, false, false);
            player.FocusCamera(_lookAt);
        }

        public override void Exit(GamePlayer player)
        {
            player.ReleaseCamera();
        }
    }
}
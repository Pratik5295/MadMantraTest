using MMTest.Gameplay.Player;
using UnityEngine;

namespace MMTest.Gameplay
{
    public class DialogueState : GameState
    {
        private Transform _npc;
        public DialogueState(Transform npc)
        {
            _npc = npc;
        }
        public override void Enter(GamePlayer player)
        {
            player.SetControls(movement: false, look: true, false, false, true);
            player.Look.SetConstraints(_npc.position);
        }
        public override void Exit(GamePlayer player)
        {
            player.Look.ResetDialogueMode();
        }
    }
}
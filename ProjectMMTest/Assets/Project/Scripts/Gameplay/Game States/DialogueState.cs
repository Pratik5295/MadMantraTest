using MMTest.Gameplay.Player;
using UnityEngine;

namespace MMTest.Gameplay
{
    public class DialogueState : GameState
    {
        private NPCInteractable _npc;
        public DialogueState(NPCInteractable npc)
        {
            _npc = npc;
        }
        public override void Enter(GamePlayer player)
        {
            player.SetControls(movement: false, look: true, false, false, true);
            player.Look.SetConstraints(_npc.Head.position);
            player.FocusCamera(_npc.FocusPoint);
        }
        public override void Exit(GamePlayer player)
        {
            player.Look.ResetDialogueMode();
            player.ReleaseCamera();
        }
    }
}
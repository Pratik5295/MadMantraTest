using MMTest.Gameplay.Player;

namespace MMTest.Gameplay
{
    public abstract class GameState
    {
        public abstract void Enter(GamePlayer player);
        public virtual void Exit(GamePlayer player) { }
        public virtual void Tick(GamePlayer player) { }

    }
}
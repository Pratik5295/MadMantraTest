using MMTest.Gameplay.Player;
using MMTest.Mangaers;
using UnityEngine;
using UnityEngine.Playables;

namespace MMTest.Gameplay
{
    public class CinematicTrigger : MonoBehaviour
    {
        [SerializeField]
        private BaseTriggerable _triggerable;

        [SerializeField]
        private PlayableDirector _scene;

        private GamePlayer _player;
        private bool _isCompleted = false;

        private void OnEnable()
        {
            _triggerable.OnPlayerEnter += OnPlayerEnter;
            
        }
        private void OnDisable()
        {
            _triggerable.OnPlayerEnter -= OnPlayerEnter;
        }

        private void OnPlayerEnter(GameObject player)
        {
            _player = player.GetComponent<GamePlayer>();

            _player.State.SwitchToCinematicMode();

            CinematicManager.Instance.StartCinematic(_scene, OnCinematicComplete);
        }

        protected virtual void OnCinematicComplete()
        {
            Debug.Log("Cinematic Scene Complete");
            _player.State.SwitchToGameplay();
            _player = null;

            _isCompleted = true;
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.Playables;

namespace MMTest.Mangaers
{
    public class CinematicManager : MonoBehaviour
    {
        public static CinematicManager Instance { get; private set; }

        private PlayableDirector _current;

        private Action _onFinished;

        private void Awake()
        {
            if(Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void OnDestroy()
        {
            if (Instance == this) Instance = null;
        }

        public void StartCinematic(PlayableDirector director, Action onFinished = null)
        {
            if (_current != null) StopCinematic();

            _current = director;

            _onFinished = onFinished;

            _current.stopped += OnStopped;
            _current.Play();
        }

        public void StopCinematic()
        {
            _current?.Stop();
        }

        public void PauseCinematic()
        {
            _current?.Pause();
        }

        public void ResumeCinematic()
        {
            _current?.Resume();
        }

        private void OnStopped(PlayableDirector director)
        {
            director.stopped -= OnStopped;
            _current = null;

            var done = _onFinished;
            _onFinished = null;

            if (done != null) done();
        }
    }
}
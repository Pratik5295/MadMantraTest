using UnityEngine;

namespace MMTest.Misc
{
    [RequireComponent(typeof(Light))]
    public class LightFlicker : MonoBehaviour
    {
        [SerializeField] private float _minIntensity = 0f;
        [SerializeField] private float _maxIntensity = 3f;
        [SerializeField] private float _speed = 8f;                     // how fast it flickers
        [SerializeField, Range(0f, 1f)] private float _irregularity = 0.6f;
        [SerializeField] private float _blackoutsPerSecond = 0.5f;      // sudden short drops to dark
        [SerializeField] private bool _flickerOnStart = false;

        private Light _light;
        private bool _isFlickering;
        private float _seed;

        private void Awake()
        {
            _light = GetComponent<Light>();
            _seed = Random.value * 100f;
            _isFlickering = _flickerOnStart;
        }

        public void StartFlicker() => _isFlickering = true;

        public void SetFullOn()
        {
            _isFlickering = false;
            _light.intensity = _maxIntensity;
        }

        private void Update()
        {
            if (!_isFlickering) return;

            float t = Time.time * _speed + _seed;

            float wave = Mathf.Sin(t) * 0.5f + 0.5f;
            float noise = Mathf.PerlinNoise(t * 2f, _seed);
            float value = Mathf.Lerp(wave, noise, _irregularity);

            if (Random.value < _blackoutsPerSecond * Time.deltaTime)
                value = 0f;

            _light.intensity = Mathf.Lerp(_minIntensity, _maxIntensity, value);
        }
    }
}
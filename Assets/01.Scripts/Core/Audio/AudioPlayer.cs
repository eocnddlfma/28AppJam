using UnityEngine;

namespace BSM.Core.Audios
{
    public class AudioPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Initialize(AudioClip clip, bool isRepeat)
        {
            _audioSource.clip = clip;
            _audioSource.loop = isRepeat;
            _audioSource.Play();
        }
    }
}

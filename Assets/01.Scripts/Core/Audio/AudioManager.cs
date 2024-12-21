using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SSH.Core.Audios
{
    public class AudioManager : MonoSingleton<AudioManager>
    {
        public AudioBaseSO audioBase;
        public AudioPair[] audioPairs;
        private Dictionary<string, AudioClip> _audioDictionary;
        [SerializeField] private GameObject _audioPlayer;
        private GameObject[] _audioPlayers = new GameObject[99];
        private int index = 0;
        
        private void Awake()
        {
            AddAudiosToDictionary();
            for (int i = 1; i <= 99; i++)
            {
                _audioPlayers[i - 1] = Instantiate(_audioPlayer, transform);
            }
        }

        private void AddAudiosToDictionary()
        {
            _audioDictionary = new Dictionary<string, AudioClip>();
            audioPairs.ToList().ForEach(pair => _audioDictionary.Add(pair.key, pair.clip));
        }

        public void PlayAudio(string key, bool isRepeat = false)
        {
            AudioSource audioSource = _audioPlayers[index].GetComponent<AudioSource>();
            audioSource.clip = _audioDictionary[key];
            audioSource.Play();
            index = (index + 1) % 100;
        }
    }
}

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
        public GameObject _audioPlayer;
        private List<GameObject> _audioPlayers = new List<GameObject>(); // List로 관리
        private int index = 0;
        
        private void Awake()
        {
            AddAudiosToDictionary();
            for (int i = 0; i < 99; i++)
            {
                GameObject newAudioPlayer = Instantiate(_audioPlayer, transform);
                newAudioPlayer.name = $"AudioPlayer_{i + 1}";
                _audioPlayers.Add(newAudioPlayer); // List에 추가
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
            index = (index + 1) % 99;
        }
    }
}

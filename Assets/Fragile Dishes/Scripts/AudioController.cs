using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FragileDishes
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        private AudioClip[] _soundList;

        private void Start()
        {
            _soundList = Resources.LoadAll<AudioClip>("Sounds");
        }

        public void PlayBrokenGlassSound()
        {
            if (_soundList.Length < 1) return;

            int randomIndex = Random.Range(0, _soundList.Length);

            audioSource.clip = _soundList[randomIndex];
            audioSource.Play();
        }
    }
}

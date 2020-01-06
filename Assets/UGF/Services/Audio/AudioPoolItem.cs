﻿using UGF.Util.MonoObjectPooling;
using UnityEngine;
using Zenject;

namespace UGF.Services.Audio
{
    public class AudioPoolItem : MonoBehaviour, IPoolItem
    {
        public class Factory : PlaceholderFactory<UnityEngine.Object, AudioPoolItem> { }

        [SerializeField] private AudioSource _audioSource;

        public bool IsPaused { get; private set; }
        public bool IsFree => !_audioSource.isPlaying;

        public float Volume
        {
            get { return _audioSource.volume; }
            set { _audioSource.volume = value; }
        }

        public void Play(AudioClip clip, bool loop = false, float pitch = 1)
        {
            _audioSource.clip = clip;
            _audioSource.pitch = pitch;
            _audioSource.loop = loop;

            IsPaused = false;
            _audioSource.Play();
        }

        public void Stop()
        {
            IsPaused = false;
            _audioSource.Stop();
        }

        public void Pause()
        {
            if (IsPaused || !_audioSource.isPlaying) { return; }

            IsPaused = true;
            _audioSource.Pause();
        }

        public void Resume()
        {
            if (!IsPaused) { return; }

            IsPaused = false;
            _audioSource.UnPause();
        }
    }
}

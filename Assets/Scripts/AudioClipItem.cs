using System;
using System.IO;
using UnityEngine;

namespace Interfaces.SoundSystem
{
    public class AudioClipItem : IComparable<AudioClipItem>
    {
        private string _clipLocation;
        AudioClip _clip;

        public AudioClipItem(string newClipLocation)
        {
            _clipLocation = newClipLocation;
        }

        private void LoadClip()
        {
            _clip = Resources.Load<AudioClip>(_clipLocation);
            if (!_clip)
            {
                throw new FileNotFoundException("SoundManager: path[" + _clipLocation + "] File Not Found");
            }
        }

        public AudioClip GetAudioClip()
        {
            if (!_clip)
            {
                LoadClip();
            }
            return _clip;
        }

        public int CompareTo(AudioClipItem other)
        {
            return other == null ? 1 : 0;
        }
    }
}

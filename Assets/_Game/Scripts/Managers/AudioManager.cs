using System;
using UnityEngine;

namespace TicTacToe
{
    [RequireComponent(typeof(AudioSource))]
    // AudioManager is responsible for managing audio playback in the game.
    // It handles background music and sound effects using AudioSource components.
    public class AudioManager : MonoBehaviour
    {

        #region Inspector properties

        public AudioSource backgroundMusicSource;
        public AudioSource sfxSource;

        #endregion

        #region Public properties

        #endregion

        #region Private properties

        #endregion

        #region Behaviours

        #endregion

        #region Methods

        public void PlayBackgroundMusic(AudioClip clip)
        {
            if (clip != null && backgroundMusicSource != null)
            {
                backgroundMusicSource.clip = clip;
                backgroundMusicSource.Play();
            }
        }

        public void PlaySFX(AudioClip clip)
        {
            if (clip != null && sfxSource != null)
            {
                sfxSource.PlayOneShot(clip);
            }
        }

        #endregion
    }
}

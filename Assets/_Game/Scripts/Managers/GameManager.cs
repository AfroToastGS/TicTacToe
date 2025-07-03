using System;
using UnityEngine;

namespace TicTacToe
{
    [DefaultExecutionOrder(-1000)]
    public class GameManager : MonoBehaviour
    {

        #region Inspector properties

        #endregion

        #region Public properties
        // Singleton instance
        public static GameManager Instance { get; private set; }

        public Action<EnumScenes> OnSceneChangeRequested;
        public Action<string> OnGameEndRequested;
        public Action<string> OnPlayerTurnChanged;

        #endregion

        #region Private properties

        #endregion

        #region Behaviours

        private void Awake()
        {
            // Singleton pattern implementation
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // Keep this object alive when changing scenes
            }
            else
            {
                Destroy(gameObject); // Destroy duplicate instances
            }
        }

        private void Start()
        {
            // Subscribe to the scene change event
            OnSceneChangeRequested += OnSceneChangeRequestedHandler;
        }


        private void Update()
        {

        }

        private void OnDestroy()
        {
            // Unsubscribe from the event to prevent memory leaks
            OnSceneChangeRequested -= OnSceneChangeRequestedHandler;
        }

        #endregion

        #region Methods

        private void OnSceneChangeRequestedHandler(EnumScenes scenes)
        {
            // Load the requested scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(scenes.ToSceneName());
        }

        #endregion
    }
}

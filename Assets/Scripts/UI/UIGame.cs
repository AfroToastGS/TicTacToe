using UnityEngine;

namespace TicTacToe
{
    public class UIGame : MonoBehaviour
    {

        #region Inspector properties

        #endregion

        #region Public properties

        #endregion

        #region Private properties

        #endregion

        #region Behaviours

        private void Awake()
        {

        }

        private void Start()
        {

        }

        private void Update()
        {

        }

        #endregion

        #region Methods

        public void OnBackButtonClicked()
        {
            // Request to change to the main menu scene
            GameManager.Instance.OnSceneChangeRequested?.Invoke(EnumScenes.MainMenu);
        }

        public void OnResetButtonClicked()
        {
            // Request to reset the game
            GameManager.Instance.OnSceneChangeRequested?.Invoke(EnumScenes.GameScene);
        }

        #endregion
    }
}

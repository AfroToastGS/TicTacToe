using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class UIMainMenu : MonoBehaviour
    {

        #region Inspector properties

        public Image backgroundImage;
        public Image playButton;
        public Image exitButton;

        #endregion

        #region Public properties

        #endregion

        #region Private properties

        #endregion

        #region Behaviours

        private void Awake()
        {
            // Ensure the background image is set from the GameTheme
            if (GameManager.Instance != null && GameManager.Instance.gameTheme != null)
            {
                backgroundImage.sprite = GameManager.Instance.gameTheme.mainMenuBackgroundImage;
                playButton.sprite = GameManager.Instance.gameTheme.startButtonImage;
                exitButton.sprite = GameManager.Instance.gameTheme.exitButtonImage;
            }
        }

        private void Start()
        {
        }

        private void Update()
        {

        }

        #endregion

        #region Methods

        public void OnPlayButtonClicked()
        {
            // Request to change to the game scene
            GameManager.Instance.OnSceneChangeRequested(EnumScenes.GameScene);
        }

        public void OnExitButtonClicked()
        {
            // Exit the application
            Application.Quit();
        }

        #endregion
    }
}

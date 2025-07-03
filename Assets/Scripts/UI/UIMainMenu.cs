using UnityEngine;

namespace TicTacToe
{
    public class UIMainMenu : MonoBehaviour
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

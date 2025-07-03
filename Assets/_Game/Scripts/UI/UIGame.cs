using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class UIGame : MonoBehaviour
    {

        #region Inspector properties
        public RectTransform resultView;

        public Image oPlayerTurnImage;
        public Image xPlayerTurnImage;

        #endregion

        #region Public properties

        #endregion

        #region Private properties

        #endregion

        #region Behaviours

        private void Awake()
        {
            // Subscribe to the game end event
            GameManager.Instance.OnGameEndRequested += OnGameEndRequestedHandler;
            // Subscribe to the player turn change event
            GameManager.Instance.OnPlayerTurnChanged += OnPlayerTurnChangedHandler;
        }

        private void Start()
        {
        }

        private void Update()
        {

        }

        private void OnDestroy()
        {
            // Unsubscribe from the events to prevent memory leaks
            GameManager.Instance.OnGameEndRequested -= OnGameEndRequestedHandler;
            GameManager.Instance.OnPlayerTurnChanged -= OnPlayerTurnChangedHandler;
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

        private void OnGameEndRequestedHandler(string winner)
        {
            // Show the result view
            resultView.gameObject.SetActive(true);
            // Display the winner message
            Debug.Log(string.IsNullOrEmpty(winner) ? "It's a draw!" : $"{winner} wins!");
        }

        private void OnPlayerTurnChangedHandler(string currentPlayer)
        {
            // Update the player turn images based on the current player
            if (currentPlayer == "O")
            {
                oPlayerTurnImage.color = Color.green;
                xPlayerTurnImage.color = Color.red;
            }
            else if (currentPlayer == "X")
            {
                oPlayerTurnImage.color = Color.red;
                xPlayerTurnImage.color = Color.green;
            }
        }

        #endregion
    }
}

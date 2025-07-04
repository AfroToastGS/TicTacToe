using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class UIGame : MonoBehaviour
    {

        #region Inspector properties

        [Header("Background")]
        public Image backgroundImage;

        [Header("Top Bar")]
        public Image exitButtonImage;
        public Image oPlayerTurnImage;
        public Image xPlayerTurnImage;

        [Header("Game Result")]
        public RectTransform resultView;
        public Image winnerImage;
        public Image resetButtonImage;

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

            backgroundImage.sprite = GameManager.Instance.gameTheme.gameBackgroundImage;
            exitButtonImage.sprite = GameManager.Instance.gameTheme.exitButtonImage;
            oPlayerTurnImage.sprite = GameManager.Instance.gameTheme.oPlayerImage;
            xPlayerTurnImage.sprite = GameManager.Instance.gameTheme.xPlayerImage;
            resetButtonImage.sprite = GameManager.Instance.gameTheme.restartButtonImage;
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
            GameManager.Instance.audioManager.StopSFX(); // Stop any ongoing SFX
        }

        private void OnGameEndRequestedHandler(string winner)
        {
            // Set the winner image based on the winner
            if (winner == "O")
            {
                winnerImage.sprite = GameManager.Instance.gameTheme.oPlayerWinImage;
                GameManager.Instance.audioManager.PlaySFX(
            GameManager.Instance.gameTheme.oPlayerWinSound);
            }
            else if (winner == "X")
            {
                winnerImage.sprite = GameManager.Instance.gameTheme.xPlayerWinImage;
                GameManager.Instance.audioManager.PlaySFX(
            GameManager.Instance.gameTheme.xPlayerWinSound);
            }
            else
            {
                winnerImage.sprite = GameManager.Instance.gameTheme.gameDrawImage; // No winner, it's a draw
                GameManager.Instance.audioManager.PlaySFX(
                            GameManager.Instance.gameTheme.gameDrawSound);
            }
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
                oPlayerTurnImage.sprite = GameManager.Instance.gameTheme.oPlayerTurnImage;
                xPlayerTurnImage.sprite = GameManager.Instance.gameTheme.xPlayerImage;
            }
            else if (currentPlayer == "X")
            {
                oPlayerTurnImage.sprite = GameManager.Instance.gameTheme.oPlayerImage;
                xPlayerTurnImage.sprite = GameManager.Instance.gameTheme.xPlayerTurnImage;
            }
        }

        #endregion
    }
}

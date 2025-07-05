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

        private void OnGameEndRequestedHandler(EnumGameStatus status)
        {
            // Set the winner image and sound based on the status
            switch (status)
            {
                case EnumGameStatus.OPlayerWon:
                    winnerImage.sprite = GameManager.Instance.gameTheme.oPlayerWinImage;
                    GameManager.Instance.audioManager.PlaySFX(
                GameManager.Instance.gameTheme.oPlayerWinSound);
                    break;
                case EnumGameStatus.XPlayerWon:
                    winnerImage.sprite = GameManager.Instance.gameTheme.xPlayerWinImage;
                    GameManager.Instance.audioManager.PlaySFX(
                GameManager.Instance.gameTheme.xPlayerWinSound);
                    break;
                case EnumGameStatus.Draw:
                    winnerImage.sprite = GameManager.Instance.gameTheme.gameDrawImage;
                    GameManager.Instance.audioManager.PlaySFX(
                                GameManager.Instance.gameTheme.gameDrawSound);
                    break;
            }

            // Show the result view
            resultView.gameObject.SetActive(true);
            // Display the winner message
            Debug.Log(status.ToFriendlyString());
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

using UnityEngine;

namespace TicTacToe
{
    [CreateAssetMenu(fileName = "GameTheme", menuName = "TicTacToe/GameTheme")]
    public class GameTheme : ScriptableObject
    {
        #region Images
        public Sprite mainMenuBackgroundImage;
        public Sprite gameBackgroundImage;
        public Sprite oPlayerImage;
        public Sprite xPlayerImage;
        public Sprite oPlayerTurnImage;
        public Sprite xPlayerTurnImage;
        public Sprite oPlayerWinImage;
        public Sprite xPlayerWinImage;
        public Sprite gameDrawImage;
        public Sprite startButtonImage;
        public Sprite restartButtonImage;
        public Sprite exitButtonImage;
        #endregion

        #region Audio
        public AudioClip backgroundMusic;
        public AudioClip oPlayerPressSound;
        public AudioClip xPlayerPressSound;
        public AudioClip oPlayerWinSound;
        public AudioClip xPlayerWinSound;
        public AudioClip gameDrawSound;
        #endregion

    }
}

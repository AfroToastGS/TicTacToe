using UnityEngine;

namespace TicTacToe
{
    public enum EnumScenes
    {
        MainMenu,
        GameScene
    }

    public static class EnumScenesExtensions
    {
        public static string ToSceneName(this EnumScenes scene)
        {
            return scene switch
            {
                EnumScenes.MainMenu => "MainMenu",
                EnumScenes.GameScene => "Game",
                _ => throw new System.ArgumentOutOfRangeException(nameof(scene), scene, null)
            };
        }

    }
}

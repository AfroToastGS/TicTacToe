using UnityEngine;

namespace TicTacToe
{
    public enum EnumGameStatus
    {
        OPlayerWon,
        XPlayerWon,
        Draw
    }

    public static class EnumGameStatusExtensions
    {
        public static string ToFriendlyString(this EnumGameStatus status)
        {
            return status switch
            {
                EnumGameStatus.OPlayerWon => "O Player Wins!",
                EnumGameStatus.XPlayerWon => "X Player Wins!",
                EnumGameStatus.Draw => "It's a Draw!",
                _ => "Unknown Status"
            };
        }

        public static EnumGameStatus FromString(string status)
        {
            return status switch
            {
                "O" => EnumGameStatus.OPlayerWon,
                "X" => EnumGameStatus.XPlayerWon,
                "Draw" => EnumGameStatus.Draw,
                _ => throw new System.ArgumentException("Invalid game status string")
            };
        }
    }
}

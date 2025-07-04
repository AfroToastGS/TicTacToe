using System;
using TicTacToe;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{

    #region Inspector properties

    public GameObject cellPrefab;

    #endregion

    #region Public properties


    #endregion

    #region Private properties

    private Cell[,] cells = new Cell[3, 3];
    private string currentPlayer = "O";
    private bool gameEnded = false;

    #endregion

    #region Behaviours

    private void Start()
    {
        // Link buttons from the scene by name or hierarchy
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                // Create a new button instance for each cell
                if (Instantiate(cellPrefab, transform).TryGetComponent(out Cell cell))
                {
                    // Initialize the cell with its coordinates and the click event handler
                    cell.Initialize(x, y, OnCellClicked);
                    // Set the button's position in the grid
                    cells[x, y] = cell;
                }
            }
        }

        // Notify the UI about the player turn change
        GameManager.Instance.OnPlayerTurnChanged?.Invoke(currentPlayer);
    }

    #endregion

    #region Methods

    void OnCellClicked(Cell cell)
    {
        // Check if the cell is already occupied or if the game has ended
        if (cell.IsOccupied || gameEnded) return;
        // Set the cell's value to the current player's symbol
        cell.CurrnetValue = currentPlayer;
        // Sound the click effect
        GameManager.Instance.audioManager.PlaySFX(currentPlayer == "X" ? GameManager.Instance.gameTheme.xPlayerPressSound : GameManager.Instance.gameTheme.oPlayerPressSound);
        // Check the game status after the move
        CheckGameStatus();
        // check if the game has ended
        if (!gameEnded)
        {
            // Switch to the next player
            currentPlayer = currentPlayer == "X" ? "O" : "X";
            // Notify the UI about the player turn change
            GameManager.Instance.OnPlayerTurnChanged?.Invoke(currentPlayer);
        }
    }

    void CheckGameStatus()
    {
        // Check rows and columns
        for (int i = 0; i < 3; i++)
        {
            if (!string.IsNullOrEmpty(cells[i, 0].CurrnetValue) &&
                cells[i, 0] == cells[i, 1] && cells[i, 1] == cells[i, 2])
            {
                EndGame(cells[i, 0].CurrnetValue);
                return;
            }

            if (!string.IsNullOrEmpty(cells[0, i].CurrnetValue) &&
                cells[0, i] == cells[1, i] && cells[1, i] == cells[2, i])
            {
                EndGame(cells[0, i].CurrnetValue);
                return;
            }
        }

        // Diagonals
        if (!string.IsNullOrEmpty(cells[1, 1].CurrnetValue))
        {
            if ((cells[0, 0] == cells[1, 1] && cells[1, 1] == cells[2, 2]) ||
                (cells[0, 2] == cells[1, 1] && cells[1, 1] == cells[2, 0]))
            {
                EndGame(cells[1, 1].CurrnetValue);
                return;
            }
        }

        // Draw
        bool draw = true;
        foreach (var cell in cells)
        {
            if (string.IsNullOrEmpty(cell.CurrnetValue))
            {
                draw = false;
                break;
            }
        }

        if (draw)
            EndGame("");
    }

    void EndGame(string message)
    {
        // Set the result view active to show the end game message
        gameEnded = true;
        // Notify the game manager about the game end
        GameManager.Instance.OnGameEndRequested?.Invoke(message);
    }

    #endregion

}

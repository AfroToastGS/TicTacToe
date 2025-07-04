using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class Cell : MonoBehaviour
    {

        #region Inspector properties

        public Image cellImage;

        #endregion

        #region Public properties
        public string CurrnetValue
        {
            get => currnetValue;
            set
            {
                currnetValue = value;
                // Update the cell's visual representation here if needed
                cellImage.sprite = currnetValue == "X" ? GameManager.Instance.gameTheme.xPlayerImage :
                                currnetValue == "O" ? GameManager.Instance.gameTheme.oPlayerImage :
                                null; // Set to null or a default sprite if empty
                cellImage.color = string.IsNullOrEmpty(currnetValue) ? new Color(1f, 1f, 1f, 0f) : Color.white; // Reset color if empty
            }
        }

        public bool IsOccupied => currnetValue != "";

        #endregion

        #region Private properties

        private int x;
        private int y;

        private Action<Cell> onCellClickedAction;

        private string currnetValue = "";

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

        public void Initialize(int x, int y, Action<Cell> onCellClickedAction)
        {
            this.x = x;
            this.y = y;
            this.onCellClickedAction = onCellClickedAction;
            CurrnetValue = "";
        }

        public void OnCellButtonClicked()
        {
            onCellClickedAction?.Invoke(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is Cell other)
            {
                return currnetValue == other.currnetValue;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y, currnetValue);
        }

        public static bool operator ==(Cell left, Cell right)
        {
            if (ReferenceEquals(left, right))
                return true;
            if (left is null || right is null)
                return false;
            return left.Equals(right);
        }

        public static bool operator !=(Cell left, Cell right)
        {
            return !(left == right);
        }

        #endregion
    }
}

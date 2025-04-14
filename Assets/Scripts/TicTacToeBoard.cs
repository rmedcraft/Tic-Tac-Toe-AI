public enum CellState {
    Empty,
    X,
    O
}
public class TicTacToeBoard {
    public CellState[,] board = new CellState[3, 3];
    // Initializes the board by resetting all cells to empty

    public void Init() {
        
    }
    
    public void ResetBoard() {
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                board[x, y] = CellState.Empty;
            }
        }
    }
    // Checks if the board is full (no empty cells)
    public bool IsBoardFull() {
        foreach (CellState cell in board) {
            if (cell == CellState.Empty)
                return false;
        }
        return true;
    }
}
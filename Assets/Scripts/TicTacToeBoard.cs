public enum CellState {
    Empty,
    X,
    O
}
public class TicTacToeBoard {
    public Node[,] board = new Node[3, 3];

    // Initializes the board by resetting all cells to empty
    public void Init(Graph graph) {
        for (int r = 0; r < 3; r++) {
            for (int c = 0; c < 3; c++) {
                board[r, c] = graph.nodes[r, c];
            }
        }
    }

    public void ResetBoard() {
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                board[x, y].cellState = CellState.Empty;
            }
        }
    }
    // Checks if the board is full (no empty cells)
    public bool IsBoardFull() {
        foreach (Node n in board) {
            if (n.cellState == CellState.Empty) {
                return false;
            }
        }
        return true;
    }
}
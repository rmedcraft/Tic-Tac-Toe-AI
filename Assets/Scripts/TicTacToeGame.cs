using UnityEngine;
public class TicTacToeGame : MonoBehaviour {
    public TicTacToeBoard board;
    public bool isPlayerXTurn = true; // Player X starts

    public Graph graph;
    GraphView graphView;

    // Initializes the game
    public void Start() {
        if (graph != null) {
            graph.Init(this);
            graphView = graph.GetComponent<GraphView>();
            if (graphView != null) {
                graphView.Init(graph, this);
            } else {
                Debug.Log("No graph view is found");
            }
        }

        board = new TicTacToeBoard();
        board.Init(graph);
        UpdateBoardUI();
    }
    // Called when a cell is clicked by the user
    public void OnCellClicked(int x, int y) {
        Debug.Log("Cell State: " + board.board[x, y].cellState);
        Debug.Log("Is Player X Turn: " + isPlayerXTurn);

        if (board.board[x, y].cellState == CellState.Empty && isPlayerXTurn) {
            // Player X places their move
            board.board[x, y].cellState = CellState.X;
            Debug.Log("OnCellClicked");

            isPlayerXTurn = false; // Switch turn to AI
            UpdateBoardUI(); // Update the UI
            if (CheckForWinner()) {
                Debug.Log("Player X wins!");
            } else if (board.IsBoardFull()) {
                Debug.Log("Its a draw!");
            } else {
                // Now it’s AI’s turn
                AITurn();
            }
        }
    }
    // Checks if there is a winner
    public bool CheckForWinner() {
        // Implement logic for checking rows, columns, and diagonals
        return false;
    }
    // Updates the UI to reflect the board state
    public void UpdateBoardUI() {
        // Implement logic for updating the UI with the current board state
        Debug.Log("Update Board UI");
        graphView.UpdateNodes();
    }
    // Makes the AI (Player O) take its turn
    public void AITurn() {
        // Implement logic for AI’s move using the Minimax algorithm
    }
    // Implements the Minimax algorithm to evaluate possible moves
    public int Minimax(TicTacToeBoard board, bool isMaximizing) {
        // Implement the Minimax algorithm
        return -1;
    }
    // Resets the game for a new match
    public void ResetGame() {
        board.ResetBoard();
        isPlayerXTurn = true; // Player X starts

        UpdateBoardUI();
    }
}
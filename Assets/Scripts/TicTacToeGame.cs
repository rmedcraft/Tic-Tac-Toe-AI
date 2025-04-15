using UnityEngine;
public class TicTacToeGame : MonoBehaviour {
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

        UpdateBoardUI();
    }
    // Called when a cell is clicked by the user
    public void OnCellClicked(int x, int y) {

        if (graph.nodes[x, y].cellState == CellState.Empty && isPlayerXTurn) {
            // Player X places their move
            graph.nodes[x, y].cellState = CellState.X;

            isPlayerXTurn = false; // Switch turn to AI
            UpdateBoardUI(); // Update the UI
            if (CheckForWinner()) {
                Debug.Log("Player X wins!");
            } else if (graph.IsBoardFull()) {
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
        // initialize the list of winning pairs
        Vector2[] dir1 = { new Vector2(1f, 1f), new Vector2(-1f, -1f) };
        Vector2[] dir2 = { new Vector2(1f, 0f), new Vector2(-1f, 0f) };
        Vector2[] dir3 = { new Vector2(1f, -1f), new Vector2(-1f, 1f) };
        Vector2[] dir4 = { new Vector2(0f, 1f), new Vector2(0f, -1f) };
        Vector2[][] checkDirections = { dir1, dir2, dir3, dir4 };
        for (int r = 0; r < 3; r++) {
            for (int c = 0; c < 3; c++) {
                // check all directions, see if winner
                Node n = graph.nodes[r, c];
                if (n.cellState == CellState.Empty) {
                    continue;
                }

                foreach (Vector2[] dirs in checkDirections) {
                    bool won = true;
                    foreach (Vector2 dir in dirs) {

                        int newX = (int)(n.position.x + dir.x);
                        int newY = (int)(n.position.z + dir.y);
                        if (!(graph.IsWithinBounds(newX, newY) && graph.nodes[newX, newY].cellState == n.cellState)) {
                            won = false;
                            break;
                        }
                    }
                    if (won) {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    // Updates the UI to reflect the board state
    public void UpdateBoardUI() {
        // Implement logic for updating the UI with the current board state
        graphView.UpdateNodes();
    }
    // Makes the AI (Player O) take its turn
    public void AITurn() {
        // Implement logic for AI’s move using the Minimax algorithm
    }
    // Implements the Minimax algorithm to evaluate possible moves
    public int Minimax(Node[,] nodes, bool isMaximizing) {
        // Implement the Minimax algorithm
        if (CheckForWinner()) {

        }
        return -1;
    }
    // Resets the game for a new match
    public void ResetGame() {
        graph.ResetBoard();
        isPlayerXTurn = true; // Player X starts

        UpdateBoardUI();
    }
}
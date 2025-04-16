using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class TicTacToeGame : MonoBehaviour {
    public bool isPlayerXTurn = true; // Player X starts

    public Graph graph;
    GraphView graphView;
    LineRenderer lineRenderer;

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

        // parameters for the line indicating the end of the game
        lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
        lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
        lineRenderer.SetPosition(1, new Vector3(0, 0, 0));
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
    // Returns 1 if X won, 0 if no one won, and -1 if O won
    public int Utility(bool winLine) {
        // Implement logic for checking rows, columns, and diagonals
        // initialize the list of winning pairs
        Vector2[] dir1 = { new Vector2(1f, 1f), new Vector2(-1f, -1f) };
        Vector2[] dir2 = { new Vector2(1f, 0f), new Vector2(-1f, 0f) };
        Vector2[] dir3 = { new Vector2(1f, -1f), new Vector2(-1f, 1f) };
        Vector2[] dir4 = { new Vector2(0f, 1f), new Vector2(0f, -1f) };
        Vector2[][] checkDirections = { dir1, dir2, dir3, dir4 };

        // loop through each node in nodes
        foreach (Node n in graph.nodes) {
            if (n.cellState == CellState.Empty) {
                continue;
            }

            foreach (Vector2[] dirs in checkDirections) {
                int won = n.cellState == CellState.X ? 1 : -1;
                foreach (Vector2 dir in dirs) {

                    int newX = (int)(n.position.x + dir.x);
                    int newY = (int)(n.position.z + dir.y);
                    if (!(graph.IsWithinBounds(newX, newY) && graph.nodes[newX, newY].cellState == n.cellState)) {
                        won = 0;
                        break;
                    }
                }
                if (won != 0) {
                    if (winLine) {
                        Node n1 = graph.nodes[(int)(n.position.x + dirs[0].x), (int)(n.position.z + dirs[0].y)];
                        Node n2 = graph.nodes[(int)(n.position.x + dirs[1].x), (int)(n.position.z + dirs[1].y)];
                        DrawWinLine(n1, n2);
                    }
                    return won;
                }
            }
        }
        return 0;
    }

    public void DrawWinLine(Node n1, Node n2) {
        //For drawing line in the world space, provide the x,y,z values
        lineRenderer.SetPosition(0, new Vector3(n1.position.x, 0, n1.position.z)); //x,y and z position of the starting point of the line
        lineRenderer.SetPosition(1, new Vector3(n2.position.x, 0, n2.position.z)); //x,y and z position of the end point of the line
    }
    public bool CheckForWinner() {
        return Utility(true) != 0;
    }

    // Updates the UI to reflect the board state
    public void UpdateBoardUI() {
        // Implement logic for updating the UI with the current board state
        graphView.UpdateNodes();
    }

    // Makes the AI (Player O) take its turn
    public void AITurn() {
        // Implement logic for AI’s move using the Minimax algorithm
        Dictionary<int, Node> valToNode = new Dictionary<int, Node>();
        foreach (Node n in graph.nodes) {
            if (n.cellState != CellState.Empty) {
                continue;
            }

            n.cellState = CellState.O;
            int key = Minimax(graph.nodes, true);

            if (!valToNode.ContainsKey(key)) {
                valToNode.Add(Minimax(graph.nodes, true), n);
            }
            n.cellState = CellState.Empty;
        }

        // find the node with the lowest value, set its cellstate to CellState.O
        valToNode[valToNode.Min(x => x.Key)].cellState = CellState.O;

        UpdateBoardUI();
        if (CheckForWinner()) {
            Debug.Log("Player O Wins!");
            // Dont let player X go again if the game is over
        } else {
            isPlayerXTurn = true;
        }
    }
    // Implements the Minimax algorithm to evaluate possible moves
    public int Minimax(Node[,] nodes, bool isMaximizing) {
        // Implement the Minimax algorithm
        int utility = Utility(false);
        // checks for a winner or draw
        if (utility != 0 || graph.IsBoardFull()) {
            return utility;
        }

        // X is the maximizing player, O is the minimizing player
        CellState playerCell = isMaximizing ? CellState.X : CellState.O;

        // create a list of Node[,] of all possible moves
        List<int> resultList = new List<int>();
        foreach (Node n in nodes) {
            if (n.cellState != CellState.Empty) {
                continue;
            }

            n.cellState = playerCell;

            resultList.Add(Minimax(nodes, !isMaximizing));

            n.cellState = CellState.Empty;
        }

        if (isMaximizing) {
            // return Mathf.Max();
            return Enumerable.Max(resultList);
        }
        return Enumerable.Min(resultList);
    }
    // Resets the game for a new match
    public void ResetGame() {
        graph.ResetBoard();
        isPlayerXTurn = true; // Player X starts

        UpdateBoardUI();
    }
}
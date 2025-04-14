using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GraphView : MonoBehaviour {
    public GameObject nodeViewPrefab;
    public Color closedColor = Color.gray;
    public NodeView[,] nodeViews;
    Graph graph;
    TicTacToeGame game;


    public void Init(Graph graph, TicTacToeGame game) {
        if (graph == null) {
            Debug.LogWarning("Graph does not exist u stupid idiot");
            return;
        }
        this.game = game;
        this.graph = graph;

        nodeViews = new NodeView[graph.GetWidth(), graph.GetHeight()];
        foreach (Node n in graph.nodes) {
            GameObject instance = Instantiate(nodeViewPrefab, Vector3.zero, Quaternion.identity);
            NodeView nodeView = instance.GetComponent<NodeView>();
            Debug.Log("Position: " + n.position.x + ", " + n.position.z);
            if (nodeView != null) {
                nodeView.Init(n, game);
                nodeViews[n.xIndex, n.yIndex] = nodeView;
                nodeView.ColorNode(closedColor);
                // Handles.Label(n.position, "X");
                // if (n.nodeType == NodeType.mine) {
                //     nodeView.ColorNode(mineColor);
                // } else {
                //     nodeView.ColorNode(openColor);
                // }
            }
        }
    }

    public void UpdateNodes() {
        Debug.Log("Update nodes");
        foreach (Node n in graph.nodes) {
            Debug.Log(n.cellState);
            if (n != null) {
                NodeView nodeView = nodeViews[n.xIndex, n.yIndex];
                if (nodeView != null) {
                    if (n.cellState == CellState.Empty) {
                        nodeView.DrawText("");
                    } else if (n.cellState == CellState.X) {
                        Debug.Log("Cell State X");
                        nodeView.DrawText("X");
                    } else if (n.cellState == CellState.O) {
                        nodeView.DrawText("O");
                    }
                }
            }
        }
    }
}

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GraphView : MonoBehaviour {
    public GameObject nodeViewPrefab;
    public Color closedColor = Color.gray;
    public NodeView[,] nodeViews;

    public void Init(Graph graph) {
        if (graph == null) {
            Debug.LogWarning("Graph does not exist u stupid idiot");
            return;
        }

        nodeViews = new NodeView[graph.GetWidth(), graph.GetHeight()];
        foreach (Node n in graph.nodes) {
            GameObject instance = Instantiate(nodeViewPrefab, Vector3.zero, Quaternion.identity);
            NodeView nodeView = instance.GetComponent<NodeView>();
            Debug.Log("Position: " + n.position.x + ", " + n.position.z);
            if (nodeView != null) {
                nodeView.Init(n);
                nodeViews[n.xIndex, n.yIndex] = nodeView;
                nodeView.ColorNode(closedColor);
                DrawText(n, "X");
                // Handles.Label(n.position, "X");
                // if (n.nodeType == NodeType.mine) {
                //     nodeView.ColorNode(mineColor);
                // } else {
                //     nodeView.ColorNode(openColor);
                // }
            }
        }
    }

    public void DrawText(Node n, string s) {
        GameObject text = new GameObject();
        TextMesh t = text.AddComponent<TextMesh>();
        t.text = s;
        t.fontSize = 40;
        t.characterSize = 0.2f;

        t.transform.position = n.position;

        t.transform.eulerAngles = new Vector3(90, 0, 0);
        t.anchor = TextAnchor.MiddleCenter;

    }

    public void ColorNodes(List<Node> nodes, Color color) {
        foreach (Node n in nodes) {
            if (n != null) {
                NodeView nodeView = nodeViews[n.xIndex, n.yIndex];
                if (nodeView != null) {
                    nodeView.ColorNode(color);
                }
            }
        }
    }
}

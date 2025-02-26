using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Node start;
    Node goal;

    Graph graph;
    GraphView graphView;
    Queue<Node> frontierNodes;
    List<Node> exploreNodes;
    List<Node> pathNodes;

    public Color startColor = Color.green;
    public Color goalColor = Color.red;
    public Color frontierColor = Color.magenta;
    public Color exploreColor = Color.gray;
    public Color pathColor = Color.cyan;

    public void Init(Graph graph, GraphView graphView, Node start, Node goal)
    {
        if (start == null || goal == null || graphView == null || graph == null)
        {
            Debug.LogWarning("Pathfinder error: Missing components.");
            return;
        }
        if (start.nodeType == NodeType.blocked || goal.nodeType == NodeType.blocked)
        {
            Debug.LogWarning("Pathfinder error: Make sure start and goal nodes are open");
            return;
        }

        this.graph = graph;
        this.graphView = graphView;
        this.start = start;
        this.goal = goal;
        NodeView startNodeView = graphView.nodeViews[start.xIndex, start.yIndex];
        NodeView goalNodeView = graphView.nodeViews[goal.xIndex, goal.yIndex];
        if (startNodeView != null)
        {
            startNodeView.ColorNode(startColor);
        }
        if (goalNodeView != null)
        {
            goalNodeView.ColorNode(goalColor);
        }
    }


}

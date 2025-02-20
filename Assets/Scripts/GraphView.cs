using UnityEngine;

public class GraphView : MonoBehaviour
{
    public GameObject nodeViewPrefab;
    public Color openColor = Color.white;
    public Color blockedColor = Color.black;
    public void Init(Graph graph)
    {
        if (graph == null)
        {
            Debug.LogWarning("Graph does not exist u stupid idiot");
            return;
        }

        foreach (Node n in graph.nodes)
        {
            GameObject instance = Instantiate(nodeViewPrefab, Vector3.zero, Quaternion.identity);
            NodeView nodeView = instance.GetComponent<NodeView>();
            if (nodeView != null)
            {
                nodeView.Init(n);
                if (n.nodeType == NodeType.blocked)
                {
                    nodeView.ColorNode(blockedColor);
                }
                else
                {
                    nodeView.ColorNode(openColor);
                }
            }
        }
    }
}

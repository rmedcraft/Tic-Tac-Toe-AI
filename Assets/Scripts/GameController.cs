using UnityEngine;

public class GameController : MonoBehaviour
{
    public MapData mapData;
    public Graph graph;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (mapData != null && graph != null)
        {
            int[,] mapInstance = mapData.MakeMap();
            graph.Init(mapInstance);
            GraphView graphView = graph.gameObject.GetComponent<GraphView>();
            if (graphView != null)
            {
                graphView.Init(graph);
            }
            else
            {
                Debug.Log("No graph view is found");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

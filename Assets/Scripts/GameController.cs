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
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

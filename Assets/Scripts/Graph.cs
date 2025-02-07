using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Node[,] nodes;
    public List<Node> walls = new List<Node>();

    int[,] mapData;
    int nWidth;
    int nHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void Init(int[,] mapData)
    {
        this.mapData = mapData;
        nWidth = mapData.GetLength(0);
        nHeight = mapData.GetLength(1);
        for (int r = 0; r < nWidth; r++)
        {
            for (int c = 0; c < nHeight; c++)
            {
                // converts the graph data to node objects.
                nodes[r, c] = new Node(r, c, (NodeType)mapData[r, c]);
            }
        }
    }
}

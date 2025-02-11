using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    // Translates 1's and 0's from MapData.cs to an array of nodes
    public Node[,] nodes; //Array of nodes
    public List<Node> walls = new List<Node>();

    int[,] m_mapData;
    int m_width;
    int m_height;

    public static readonly Vector2[] allDirections = {
        new Vector2(1f, 1f),
        new Vector2(1f, 0f),
        new Vector2(1f, -1f),
        new Vector2(0f, 1f),
        new Vector2(0f, -1f),
        new Vector2(-1f, 1f),
        new Vector2(-1f, 0f),
        new Vector2(-1f, 1f),
    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void Init(int[,] mapData)
    {
        m_mapData = mapData;
        m_width = mapData.GetLength(0);
        m_height = mapData.GetLength(1);
        nodes = new Node[m_width, m_height];
        for (int c = 0; c < m_height; c++)
        {
            for (int r = 0; r < m_width; r++)
            {
                NodeType nodeType = (NodeType)mapData[r, c];
                Node newNode = new Node(r, c, nodeType);
                nodes[r, c] = newNode;
                newNode.position = new Vector3(r, 0, c);
                if (nodeType == NodeType.blocked)
                {
                    walls.Add(newNode);
                }
            }
        }

        // whatever
        for (int c = 0; c < m_height; c++)
        {
            for (int r = 0; r < m_width; r++)
            {
                if (nodes[r, c].nodeType != NodeType.blocked)
                {
                    nodes[r, c].neighbors = GetNeighbors(r, c, nodes, allDirections);
                }
            }
        }
    }

    public bool IsWithinBounds(int x, int y)
    {
        return x >= 0 && x < m_width && y >= 0 && y < m_height;
    }

    public List<Node> GetNeighbors(int x, int y, Node[,] nodeArray, Vector2[] directions)
    {
        List<Node> neighbors = new List<Node>();

        foreach (Vector2 dir in directions)
        {
            int newX = x + (int)dir.x;
            int newY = y + (int)dir.y;
            if (IsWithinBounds(newX, newY) && nodeArray[newX, newY] != null && nodeArray[newX, newY].nodeType != NodeType.blocked)
            {
                neighbors.Add(nodeArray[newX, newY]);
            }
        }

        return neighbors;
    }
}
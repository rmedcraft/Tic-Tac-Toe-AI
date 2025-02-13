using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour
{
    public int height = 5;
    public int width = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // syntax for making a 2D array
    public int[,] MakeMap()
    {
        int[,] map = new int[width, height];
        for (int r = 0; r < width; r++)
        {
            for (int c = 0; c < height; c++)
            {
                map[r, c] = 0;
            }
        }
        map[0, 3] = 1;
        map[1, 4] = 1;
        return map;
    }
}

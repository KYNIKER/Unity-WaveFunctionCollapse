using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Map = GenerateMap(Width, Height, false);
        Map[1, 1] = 0;
        RenderMap(Map, TileMap, BaseTile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Width;
    public int Height;

    public TileBase BaseTile;
    public Tilemap TileMap;

    private int[,] Map;

    public static int[,] GenerateMap(int width, int height, bool empty)
    {
        int[,] map = new int[width, height];

        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                if (empty)
                {
                    map[x, y] = 0;
                }
                else
                {
                    map[x, y] = 1;
                }
            }
        }

        return map;
    }

    public static void RenderMap(int[,] map, Tilemap tilemap, TileBase tile)
    {
        tilemap.ClearAllTiles();

        for(int x = 0; x < map.GetUpperBound(0); x++)
        {
            for(int y = 0; y < map.GetUpperBound(1); y++)
            {
                if (map[x, y] == 1)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                }
            }
        }
    }

    public static void UpdateMap(int[,] map, Tilemap tilemap)
    {
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                if (map[x, y] == 0)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), null);
                }
            }
        }
    }

}

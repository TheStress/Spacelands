using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    Grid grid;
    public float roomWidth;
    public float roomHeight;
    Vector2[] existingRooms = { new Vector2(0, 0) };

    public int numberOfRooms;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid();
    }

    // Update is called once per frame
    void Update()
    {
        //spawning rooms
        Vector2[] spawnableRooms = { new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1), new Vector2(-1, 0) };
        for(int i = 0; i < numberOfRooms; i++)
        {
            for(int j = 0; j < existingRooms.Length; j++)
            {

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] roomLayouts;

    public List<GameObject> rooms;

    private int chance;

    private float timer = 2;
    private bool spawnedLayouts = false;

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0 && spawnedLayouts == false)
        {
            AddLayouts();
            spawnedLayouts = true;
        }
    }
    public void AddLayouts()
    {
        for (int i = 1; i < rooms.Count; i++)
        {
            chance = Random.Range(0, roomLayouts.Length);
            Instantiate(roomLayouts[chance], rooms[i].transform.position, rooms[i].transform.rotation);
        }
    }
}

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
    public GameObject exitRoomLayout;
    public GameObject[] zombies;

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
        for (int i = 1; i < rooms.Count - 1; i++)
        {
            //Spawning layouts
            chance = Random.Range(0, roomLayouts.Length);
            GameObject currentLayout = Instantiate(roomLayouts[chance], rooms[i].transform.position, rooms[i].transform.rotation);

            //Spawning enemies
            Transform enemySpawn = currentLayout.transform.Find("EnemySpawn");
            for (int j = 0; j < enemySpawn.childCount; j++)
            {
                Transform enemySpawnPoint = enemySpawn.GetChild(j);
                chance = Random.Range(0, zombies.Length);
                Instantiate(zombies[chance], enemySpawnPoint.transform.position, enemySpawnPoint.transform.rotation);
            }
        }
        //Creating exit room
        Instantiate(exitRoomLayout, rooms[rooms.Count - 1].transform.position, rooms[rooms.Count - 1].transform.rotation);
    }
}

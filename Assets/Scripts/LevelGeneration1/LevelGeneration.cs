using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public int openingDirection;

    private RoomTemplates roomTemplates;
    private bool spawned = false;
    private int chance;

    private void Start()
    {
        roomTemplates = FindObjectOfType<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }
    void Spawn()
    {
        if (spawned == false)
        {
            switch (openingDirection)
            {
                case 2:
                    //Spawning room with bottom opening
                    chance = Random.Range(0, roomTemplates.bottomRooms.Length);
                    Instantiate(roomTemplates.bottomRooms[chance], transform.position, roomTemplates.bottomRooms[chance].transform.rotation);
                    break;
                case 1:
                    //Spawning room with top opening
                    chance = Random.Range(0, roomTemplates.topRooms.Length);
                    Instantiate(roomTemplates.topRooms[chance], transform.position, roomTemplates.topRooms[chance].transform.rotation);
                    break;
                case 4:
                    //Spawning room with left opening
                    chance = Random.Range(0, roomTemplates.leftRooms.Length);
                    Instantiate(roomTemplates.leftRooms[chance], transform.position, roomTemplates.leftRooms[chance].transform.rotation);
                    break;
                case 3:
                    //Spawning room with right opening
                    chance = Random.Range(0, roomTemplates.rightRooms.Length);
                    Instantiate(roomTemplates.rightRooms[chance], transform.position, roomTemplates.rightRooms[chance].transform.rotation);
                    break;
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint") && collision.GetComponent<LevelGeneration>().spawned == true)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = GameObject.Find("sword_man");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Leave the stage
        if (collision.gameObject == player)
        {
            SceneManager.LoadScene("Win");
        }
    }
}

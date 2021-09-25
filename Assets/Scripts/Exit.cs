using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Leave the stage
        SceneManager.LoadScene("Win");

    }
}

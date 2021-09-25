using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class script : MonoBehaviour
{
    public Transform transform;

    void OnMouseEnter()
    {
        transform.localScale += new Vector3(1.0f, 1.0f, 1.0f);
    }

    void OnMouseExit()
    {
        transform.localScale -= new Vector3(1.0f, 1.0f, 1.0f);
    }
    // Start is called before the first frame update
    void Start()
    {
        //transform.localScale = transform.localScale * 3.0f;
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        Debug.Log("Sprite Clicked");
        SceneManager.LoadScene("LevelGeneration1");
    }
    void Update()
    {
    }
}

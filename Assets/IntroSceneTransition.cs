using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class IntroSceneTransition : MonoBehaviour
{
    public void OnMouseDown()
    {
        Debug.Log("Sprite Clicked");
        SceneManager.LoadScene("Stages Scene");
    }
}

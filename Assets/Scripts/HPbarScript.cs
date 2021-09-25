using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HPbarScript : MonoBehaviour
{
    private Image HealthBar;
    public float currentHp;
    private float maxHp = 100f;
    PlayerController_Script player;


    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerController_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHp = player.hp;
        HealthBar.fillAmount = currentHp / maxHp;
        if(currentHp <= 0)
        {
            SceneManager.LoadScene("Stages Scene");
        }
    }
}

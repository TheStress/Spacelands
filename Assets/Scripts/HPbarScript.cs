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
    Health player;


    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
        player = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHp = player.health;
        HealthBar.fillAmount = currentHp / maxHp;
        if(currentHp <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }
}

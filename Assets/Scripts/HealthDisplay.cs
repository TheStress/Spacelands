using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private int hp = 5;
     public Text healthText;

    // Start is called before the first frame update
  

    // Update is called once per frame
     void Update()
    {
        healthText.text =  hp.ToString();
        if(Input.GetKeyDown(KeyCode.Space)){
            hp--;
        }
    }
}

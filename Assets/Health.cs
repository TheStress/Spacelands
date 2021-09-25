using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    private SpriteRenderer[] bodies;

    private float clock = 0.0f;
    private float dmgEffectDuration = 0.25f;
    private bool damaged = false;

    private Color[] ogColors;
    // Start is called before the first frame update
    void Start()
    {
        bodies = gameObject.GetComponentsInChildren<SpriteRenderer>();
        ogColors = new Color[bodies.Length];
        for (int i = 0; i < bodies.Length; i++)
        {
            ogColors[i] = bodies[i].color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0)
        {
            Destroy(gameObject);
        }

        if(damaged)
        {
            if (clock >= dmgEffectDuration)
            {
                for(int i = 0; i < bodies.Length; i++)
                {
                    bodies[i].color = ogColors[i];
                }
                clock = 0.0f;
                damaged = false;
            }
            clock += Time.deltaTime;
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].color = Color.red;
        }
        damaged = true;
    }
}

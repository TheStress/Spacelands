using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletToFire;

    public Transform firePoint;
    public AudioSource gunshot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gunshot.Play();
            Instantiate(bulletToFire, firePoint.position, transform.rotation);
        }
    }
}

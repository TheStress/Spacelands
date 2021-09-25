using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script : MonoBehaviour
{
    public Transform transform;


    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(1.0f, 1.0f,0.0f);
    }
}

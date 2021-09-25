using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTracker : MonoBehaviour
{
    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;

        Vector3 player = mainCam.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mouse.x - player.x, mouse.y - player.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}

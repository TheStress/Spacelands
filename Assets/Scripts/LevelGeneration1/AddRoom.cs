using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplates template;
    // Start is called before the first frame update
    void Start()
    {
        template = FindObjectOfType<RoomTemplates>();
        template.rooms.Add(this.gameObject);
    }
}

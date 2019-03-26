using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCameraController : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(player.transform.localPosition.x, 0.0f, -10.0f);
        transform.position = newPos;
    }
}

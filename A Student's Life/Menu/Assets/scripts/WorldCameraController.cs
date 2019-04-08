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
        float playerX = player.transform.localPosition.x;
        if (playerX < -18.5f)
            playerX = -18.5f;
        if (playerX > 18.5f)
            playerX = 18.5f;
        Vector3 newPos = new Vector3(playerX, 0.0f, -10.0f);
        transform.position = newPos;
    }
}

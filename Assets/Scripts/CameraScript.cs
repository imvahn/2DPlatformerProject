using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Transform player;

    public int offsetX;
    public int offsetY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Pink_Monster").transform;
        Vector3 pos = transform.position;
        pos.x = player.position.x + offsetX;
        if (player.position.x >= offsetX)
        {
            transform.position = pos;
        }
        pos.y = player.position.y + offsetY;
        if (player.position.y >= offsetY)
        {
            transform.position = pos;
        }
    }
}

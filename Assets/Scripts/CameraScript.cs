using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Transform player;

    public int offsetX;

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
    }
}

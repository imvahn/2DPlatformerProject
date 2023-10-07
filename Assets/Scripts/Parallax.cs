using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private Transform cameraView;

    public float parallaxScale;
    public float offsetX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraView = GameObject.Find("Main Camera").transform;
        Vector3 pos = transform.position;
        pos.x = (cameraView.position.x + offsetX) * parallaxScale;
        transform.position = pos;
    }
}

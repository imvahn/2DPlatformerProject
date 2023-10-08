using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxSky : MonoBehaviour
{

    private Transform cameraView;

    public float parallaxScale;
    public float offsetX;
    public float offsetY;

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
        pos.y = (cameraView.position.y + offsetY) * parallaxScale;
        transform.position = pos;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MovingBackground : MonoBehaviour
{
    private float lenght, startpos;
    public GameObject cam;
    public SpriteRenderer backgroundImage;
    public float parallaxEffect;

    private void Start()
    {
        startpos = transform.position.x;
        lenght = backgroundImage.bounds.size.x;
    }
    
    private void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + lenght) startpos += lenght;
        else if(temp < startpos - lenght) startpos -= lenght;

    }
}

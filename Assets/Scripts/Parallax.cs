using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    //private float length, startpos; //Deleted length because it wasn't used and was causing an error
    private float startpos;
    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        
        startpos = transform.position.x;
        //length = GetComponent<SpriteRenderer>().bounds.size.x; //Was causing an error because SpriteRenderer is not attached.
    }

    // Update is called once per frame
    void Update()
    {
        //cam = GameObject.Find("Main Camera");
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

    }
}

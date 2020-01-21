using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoorOpens()
    {
        anim.SetBool("Door", true);
    }
    public void DoorClose()
    {
        anim.SetBool("Door", false);
    }
}

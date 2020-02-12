using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.5f);
        int layerMask = 10240; //Raycast only hits layer 10+. Value is a bitmask.
                               /*
                                * To select layers that the laser will hit:
                                *      Use positive value
                                *      2^n where n is the number of the layer
                                *      2^n1 + 2^n2 ...
                                *      Example: We want to hit layers 2 and 3
                                *      2^2 + 2^3 = 4 + 8 = 12
                                *      12 is our bitmask
                                *      
                                * To select layers the laser with NOT hit:
                                *      Use negative
                                *      Start from -1
                                *      -1 - 2^n1 - 2^n2 ...
                                *      Example: We want to hit every layer EXCEPT for layer 2 and 3
                                *      -1 - 2^2 - 2^3 = -1 - 4 - 8 = -13 
                                *      -13 is our bit mask.
                                * Scary, but it works.
                                */        
        //RaycastHit2D hitInfo = Physics2D.BoxCast(FirePoint.position, Vector2.one, 0f, FirePoint.right);
        RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint.position, FirePoint.right, Mathf.Infinity, layerMask); //Parameters: Where to start the ray, the direction, how long the ray should be, layer bitmask
        var FirePointPosition = FirePoint.position + Vector3.up * 0.60f;
        if (hitInfo) //if we hit something
        {
            EnemyMovement enemy = hitInfo.transform.GetComponent<EnemyMovement>();
            print("hit: " + enemy.transform.name);

            if (enemy != null) //If we hit an enemy
            {
                enemy.ShotWithLaser();
            }

            //Shoot line to hit object
            
            lineRenderer.SetPosition(0, FirePointPosition);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            print("miss");
            lineRenderer.SetPosition(0, FirePointPosition);
            lineRenderer.SetPosition(1, FirePointPosition + FirePoint.right * 100);
        }

        lineRenderer.enabled = true;

        //wait
        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;
    }
}

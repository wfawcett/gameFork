using System.Collections;
using UnityEngine;


public class LightFlicker : MonoBehaviour
{
    public float maxFlickerSpeed = .02f;
	public float minFlickerSpeed = .01f;
    
    public void Start() {
        StartCoroutine("Flicker");
    }
    
    private IEnumerator Flicker()
    {
        while (true) {
            GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
            GetComponent<Light>().enabled = false;
            yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
       }
    }
}
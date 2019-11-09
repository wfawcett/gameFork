using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class LightFlicker : MonoBehaviour
{
    public float maxFlickerSpeed = .1f;
	public float minFlickerSpeed = 1.0f;
    
    public void Start() {
        StartCoroutine("Flicker");
    }
    
    private IEnumerator Flicker()
    {
        while (true) {
            FlickerLight.enabled = true;
            yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
            FlickerLight.enabled = false;
            yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
       }
    }
}
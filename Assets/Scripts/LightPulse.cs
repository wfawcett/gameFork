using UnityEngine;

public class LightPulse : MonoBehaviour
{
    public float duration = 3f;
    float originalRange;


    void Start()
    {
       originalRange = GetComponent<Light>().range;
    }


    public void Update()
    {
        var amplitude = GetComponent<Light>().range = Mathf.PingPong(Time.time, duration);
        amplitude = amplitude / duration * 0.5f + 0.5f;
        GetComponent<Light>().range = originalRange * amplitude;


    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickerScript : MonoBehaviour
{
    new Light light;
    private float flickerTime = 2.0f;
    private int flickerCycle = 0;

    // Start is called before the first frame update
    void Start()
    {
        light = this.GetComponent<Light>();
    }

    private void Update()
    {
        flickerTime -= Time.deltaTime;
        if (flickerTime <= 0.0f)
        {
            if (flickerCycle == 0)
            {
                light.enabled = !light.enabled;
                flickerTime = 0.5f;
                flickerCycle = 1;
            }
            else if (flickerCycle == 1)
            {
                light.enabled = !light.enabled;
                flickerTime = 1.5f;
                flickerCycle = 0;
            }
        }
    }
}

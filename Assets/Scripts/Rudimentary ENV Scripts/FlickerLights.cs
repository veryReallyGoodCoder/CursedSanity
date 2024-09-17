using System.Collections;
using UnityEngine;

public class SimpleFlickerLight : MonoBehaviour
{
    public float intensityMin = 0.0f;  // Minimum light intensity
    public float intensityMax = 1.0f;  // Maximum light intensity
    public float flickerSpeed = 0.5f;  // Speed of the flicker

    private Light lightSource;  // Reference to the attached light
    private bool increasing = true;  // To track if the intensity is increasing

    // Start is called before the first frame update
    void Start()
    {
        // Get the Light component attached to this GameObject
        lightSource = GetComponent<Light>();
        StartCoroutine(FlickerRoutine());
    }

    // Handles flickering between two intensities
    IEnumerator FlickerRoutine()
    {
        while (true)
        {
            if (increasing)
            {
                // Move intensity towards the max value
                lightSource.intensity = Mathf.MoveTowards(lightSource.intensity, intensityMax, flickerSpeed * Time.deltaTime);
                if (Mathf.Abs(lightSource.intensity - intensityMax) < 0.01f)
                {
                    increasing = false;  // Switch direction when reaching the max
                }
            }
            else
            {
                // Move intensity towards the min value
                lightSource.intensity = Mathf.MoveTowards(lightSource.intensity, intensityMin, flickerSpeed * Time.deltaTime);
                if (Mathf.Abs(lightSource.intensity - intensityMin) < 0.01f)
                {
                    increasing = true;  // Switch direction when reaching the min
                }
            }
            yield return null;  // Wait for the next frame
        }
    }
}

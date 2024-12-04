using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColour : MonoBehaviour
{
    // Reference to the Renderer component of the object
    private Renderer objectRenderer;

    // Initial and End Colors for blending
    public Color startColor = Color.red;
    public Color endColor = Color.blue;

    // Duration of the blending process (in seconds)
    public float blendDuration = 3.0f;

    // Current time in the blending process
    private float blendTime = 0.0f;

    void Start()
    {
        // Get the Renderer component attached to the GameObject
        objectRenderer = GetComponent<Renderer>();

        // Set the initial color of the material
        if (objectRenderer != null)
        {
            objectRenderer.material.color = startColor;
        }
        else
        {
            Debug.LogError("Renderer not found on this object.");
        }
    }

    void Update()
    {
        // Gradually blend the colors over time
        if (objectRenderer != null && blendTime < blendDuration)
        {
            blendTime += Time.deltaTime;  // Increase the blend time by the time passed
            float t = Mathf.Clamp01(blendTime / blendDuration); // Calculate interpolation factor between 0 and 1

            // Interpolate the color based on time (blend from startColor to endColor)
            objectRenderer.material.color = Color.Lerp(startColor, endColor, t);
        }
    }

    // Reset the blending process if needed
    public void ResetBlend()
    {
        blendTime = 0.0f; // Reset blend time
        objectRenderer.material.color = startColor; // Reset color to start color
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] Slider healthSlider;

    private Transform cameraTransform;


    private void Awake()
    {
        //camera isn't an asset, so get on awake()
        cameraTransform = GameObject.Find("Main Camera").GetComponent<Camera>().transform;
    }

    
    void Update()
    {
        //make sure the floating health bar looks good with camera roatations
        transform.rotation = cameraTransform.rotation;

    }

    /// <summary>
    /// Update the floating health bar slider
    /// </summary>
    /// <param name="currentHealth"></param>
    /// <param name="maxHealth"></param>
    public void UpdateSlider(float currentHealth, float maxHealth)
    {
        healthSlider.value = currentHealth;
        healthSlider.maxValue = maxHealth;
    }
}

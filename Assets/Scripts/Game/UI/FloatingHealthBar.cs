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

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(transform.position + cameraTransform.forward);
        transform.rotation = cameraTransform.rotation;

    }

    public void UpdateSlider(float currentHealth, float maxHealth)
    {
        healthSlider.value = currentHealth;
        healthSlider.maxValue = maxHealth;
    }
}

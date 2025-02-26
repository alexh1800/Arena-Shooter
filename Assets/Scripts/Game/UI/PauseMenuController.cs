using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenuController : MonoBehaviour
{

    /// <summary>
    /// make sure any panels you want to be able to switch to in the pause menu are added to this array
    /// </summary>
    public GameObject[] panels;  // Array to hold panel GameObjects
    private int currentPanelIndex = 0;  // Track the current panel index

    void Start()
    {
        // Initialize by showing only the first panel
        UpdatePanelVisibility();
    }

    void Update()
    {
        // Check for input to swap panels
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            SwitchToPreviousPanel();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            SwitchToNextPanel();
        }
    }

    void SwitchToPreviousPanel()
    {
        // Decrement the panel index, wrapping around if necessary
        currentPanelIndex--;
        if (currentPanelIndex < 0)
        {
            currentPanelIndex = panels.Length - 1;  // Wrap to last panel
        }
        UpdatePanelVisibility();
    }

    void SwitchToNextPanel()
    {
        // Increment the panel index, wrapping around if necessary
        currentPanelIndex++;
        if (currentPanelIndex >= panels.Length)
        {
            currentPanelIndex = 0;  // Wrap to first panel
        }
        UpdatePanelVisibility();
    }

    void UpdatePanelVisibility()
    {
        // Enable only the currently active panel
        for (int i = 0; i < panels.Length; i++)
        {
            //if the current panel is the current panel it'll be set to active, otherwise it'll be set to inactive
            if (i == currentPanelIndex)
            {
                panels[i].SetActive(true);
            }
            else
            {
                panels[i].SetActive(false);
            }
            
        }
    }
}

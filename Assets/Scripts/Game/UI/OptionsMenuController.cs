using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class OptionsMenuController : MonoBehaviour
{

    public Toggle[] toggles;  // Array to hold all toggles
    private int selectedIndex = 0;

    [SerializeField] ToggleGroup cameraGroup;
    [SerializeField] ToggleGroup controlsGroup;


    void Awake()
    {
        SetOptionsMenu();
    }

    //on enable will run every time the options menu is enabled
    void OnEnable()
    {
        // Initialize by selecting the first toggle
        UpdateToggleSelection();
        SetOptionsMenu();
    }

    void Update()
    {
        //UpdateOptions();
        //SetOptionsMenu();

        // Handle up/down arrow keys for navigation
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            NavigateUp();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            NavigateDown();
        }

        // Confirm selection with Enter or Space
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            toggles[selectedIndex].isOn = true;
            //toggles[selectedIndex].isOn = !toggles[selectedIndex].isOn;
        }
    }

    void NavigateUp()
    {
        selectedIndex--;
        if (selectedIndex < 0)
        {
            selectedIndex = toggles.Length - 1;  // Wrap around to the last toggle
        }
        UpdateToggleSelection();
    }

    void NavigateDown()
    {
        selectedIndex++;
        if (selectedIndex >= toggles.Length)
        {
            selectedIndex = 0;  // Wrap around to the first toggle
        }
        UpdateToggleSelection();
    }

    void UpdateToggleSelection()
    {
        // Highlight the currently selected toggle
        EventSystem.current.SetSelectedGameObject(toggles[selectedIndex].gameObject);
    }

    /// <summary>
    /// updates our options in GameOptions based on options menu selections
    /// needs to be set to public to be attached to the toggles
    /// 
    /// </summary>
    public void UpdateOptions()
    {
        //note: it might not hurt to add logic to make sure options menu is open


        //also add a way to set the proper toggles to active at start
        Toggle cameraToggle = cameraGroup.ActiveToggles().FirstOrDefault();
        Toggle controlToggle = controlsGroup.ActiveToggles().FirstOrDefault();


        if (cameraToggle != null)
        {
            if (cameraToggle.name == "Toggle Overhead")
            {
                GameOptions.DisplayMode = 0;
            }
            if (cameraToggle.name == "Toggle First Person")
            {
                GameOptions.DisplayMode = 1;
            }
            if (cameraToggle.name == "Toggle Third Person")
            {
                GameOptions.DisplayMode = 2;
            }
            
        }


        if(controlToggle != null)
        {
            if (controlToggle.name == "Toggle Mouse")
            {
                GameOptions.ControlMode = 0;
            }

            if (controlToggle.name == "Toggle Controller")
            {
                GameOptions.ControlMode = 1;
            }
        }
       




        
 
    }

    /// <summary>
    /// Check the proper boxes in the settings menu based on the game options settings
    /// Note: this could use some work to instead work with the menu groups as any changes or 
    /// additions to any of the menus will break this function
    /// </summary>
    void SetOptionsMenu()
    {


        if (GameOptions.DisplayMode == 0)
        {
            //print("setting display option to: 0");
            toggles[0].isOn = true; 
        }
        if (GameOptions.DisplayMode == 1)
        {
            //print("setting display option to: 1");
            toggles[1].isOn = true;
        }
        if (GameOptions.DisplayMode == 2)
        {
            //print("setting display option to: 2");
            toggles[2].isOn = true;
        }



        if (GameOptions.ControlMode == 0)
        {
            //print("setting control option to: 3");
            toggles[3].isOn = true;
        }
        if (GameOptions.ControlMode == 1)
        {
            //print("setting display option to: 4");
            toggles[4].isOn = true;
        }
    }
}

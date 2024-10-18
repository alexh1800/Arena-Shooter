using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpgradeMenuController : MonoBehaviour
{
    public Button[] upgradeButtons;  // Array of upgrade buttons
    private int selectedIndex = 0;

    void Start()
    {
        // Set the initial selected button
        EventSystem.current.SetSelectedGameObject(upgradeButtons[selectedIndex].gameObject);
    }

    void Update()
    {
        // Check if the user is pressing navigation keys
        bool isNavigating = Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0;

        // If user starts navigating with keys, refocus on the currently selected button
        if (isNavigating && EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(upgradeButtons[selectedIndex].gameObject);
        }

        // Navigation logic
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            NavigateUp();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            NavigateDown();
        }

        // Confirm selection with Enter or controller button
        if (Input.GetButtonDown("Submit"))
        {
            ConfirmSelection();
        }
    }

    void NavigateUp()
    {
        if (selectedIndex > 0)
        {
            selectedIndex--;
            EventSystem.current.SetSelectedGameObject(upgradeButtons[selectedIndex].gameObject);
        }
    }

    void NavigateDown()
    {
        if (selectedIndex < upgradeButtons.Length - 1)
        {
            selectedIndex++;
            EventSystem.current.SetSelectedGameObject(upgradeButtons[selectedIndex].gameObject);
        }
    }

    void ConfirmSelection()
    {
        upgradeButtons[selectedIndex].onClick.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameOptions
{
    /// <summary>
    /// used to set the display mode for the game:
    /// 0 = Overhead |
    /// 1 = First Person | 
    /// 2 = Third Person
    /// </summary>
    public static int displayMode = 2;


    /// <summary>
    /// used to set the controls for the game
    /// 0 = Mouse | 
    /// 1 = Twin Stick Control Mode (Or WASD and Arrows)
    /// </summary>
    public static int controlMode = 0;


    /// <summary>
    /// Key used to open the pause menu 
    /// keys are fairly self explanitory in lower case form
    /// shift, control, and alt have left and right varients represented like "right ctrl", "left shift" etc
    /// space bar is "space" enter is "return" caps lock is "caps lock"
    /// </summary>
    public static string pauseMenuKey = "right shift";


}

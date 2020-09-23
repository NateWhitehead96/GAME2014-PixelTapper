﻿/* SceneManagerScript
 * Nathan Whitehead
 * 101242269
 * 2020-09-23
 * Mobile Game Development GAME-2014
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void HowToPlay() // Function to be called on button click to switch to How to play scene
    {
        SceneManager.LoadScene("HowToPlay"); // loads instructions and how to play
    }

    public void Play() // Function to be called on button click to start the game scene
    {
        SceneManager.LoadScene("Game"); // loads the main game
    }

    public void Back() // function to be called to return to main menu
    {
        SceneManager.LoadScene("MainMenu"); // loads main menu
    }
}

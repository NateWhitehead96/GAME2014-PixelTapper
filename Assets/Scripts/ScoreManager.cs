/* ScoreManager
 * Nathan Whitehead
 * 101242269
 * 2020-10-19
 * Mobile Game Development GAME-2014
 * Does as expected, holds a static variable of score to be able to be transfered to output on our game over scene too.
 * Also prints score on the main game's UI.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    

    public static int score = 0;
    //public static int lives = 3;

    void Start()
    {
        // check to see if we are in the main game scene, if so reset score to 0
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            score = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + score;
    }
}

/* SwipeControls
 * Nathan Whitehead
 * 101242269
 * 2020-09-23
 * Mobile Game Development GAME-2014
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipeControls : MonoBehaviour
{
    // 2 Vectors for touch positions, start and end
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    // Update is called once per frame
    void Update()
    {
        // On inital touch, our start and end positions for our finger are the same
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = endTouchPosition;
        }

        // When the touch has ended the end position will get updated to where our finger comes off the screen
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            // For this game we only need vertical movement for the player
            // if there is a wipe up and the player isn't past the first keg
            if((endTouchPosition.y > startTouchPosition.y) && transform.position.y < 3f)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 2);
            }

            // if there is a swipe down and player isn't lower than last keg
            if((endTouchPosition.y < startTouchPosition.y) && transform.position.y > -3f)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 2);
            }

            // Lastly a Dev hack to switch to the game over scene
            // If you just tap it will go to game over
            if(endTouchPosition.x == startTouchPosition.x)
            {
                SceneManager.LoadScene("GameOver");
                // Will have the beverage spawn here instead of scene change.
            }
        }
    }
}

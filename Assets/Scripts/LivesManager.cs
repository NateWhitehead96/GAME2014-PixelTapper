/* LivesManager
 * Nathan Whitehead
 * 101242269
 * 2020-10-19
 * Mobile Game Development GAME-2014
 * Does as expected, just prints the lives from the player to the screen in UI.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public Text livesText = null;

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives : " + SwipeControls.lives;
    }
}

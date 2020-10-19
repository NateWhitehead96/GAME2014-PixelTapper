/* BeverageBehaviourScrip
 * Nathan Whitehead
 * 101242269
 * 2020-10-19
 * Mobile Game Development GAME-2014
 * This script controls how the beverages move.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverageBehaviourScript : MonoBehaviour
{
    public float speed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y);
        // if the beer goes off screen delete it
        if(transform.position.x < -1.8)
        {
            Destroy(gameObject);
        }

        if(transform.position.x > 1.3)
        {
            // lose a life
            SwipeControls.lives -= 1;
            Destroy(gameObject);
        }
    }
}

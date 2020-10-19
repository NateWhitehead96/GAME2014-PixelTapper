/* PatronBehaviourScript
 * Nathan Whitehead
 * 101242269
 * 2020-10-19
 * Mobile Game Development GAME-2014
 * This script is everything to control the patrons. Their moving and collisions.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronBehaviourScript : MonoBehaviour
{
    public SpriteRenderer renderer;
    public float speed;
    public GameObject emptyPrefab;

    

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y);

        if (transform.position.x < -2.5)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > 1.3)
        {
            // lose life
            SwipeControls.lives -= 1;
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "beer") // if the patron collides with beer, send him back
        {
            renderer.flipX = true;
            ScoreManager.score += 1;
            speed *= -1;
            Destroy(collision.gameObject);

            // Will randomize if they send the empty mug back

            int random = Random.Range(0, 2);
            if(random == 1)
            {
                Instantiate(emptyPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}

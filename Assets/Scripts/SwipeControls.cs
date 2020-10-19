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

    public GameObject beerPrefab;
    public AnimationClip pourClip;
    
    Animator animator;

    public static int lives = 3;

    public AudioSource beerFill;
    public AudioSource emptyCollect;

    void Start()
    {
        animator = GetComponent<Animator>();
        lives = 3;
    }

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
            // if there is a swipe up and the player isn't past the first keg
            if ((endTouchPosition.y > startTouchPosition.y + 2) && transform.position.y < 3f)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 2);
            }

            // if there is a swipe down and player isn't lower than last keg
            else if((endTouchPosition.y < startTouchPosition.y - 2) && transform.position.y > -3f)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 2);
            }

            else if (endTouchPosition.x == startTouchPosition.x)
            {
                //animation.Play();
                animator.Play("BeerPour");
                beerFill.Play();
                Instantiate(beerPrefab, transform.position, Quaternion.identity);
            }
        }

        // if lives are 0 go to lose scene
        if (lives == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "empty")
        {
            // score point
            ScoreManager.score += 1;
            // play sfx
            emptyCollect.Play();
            Destroy(collision.gameObject);
        }
    }
}

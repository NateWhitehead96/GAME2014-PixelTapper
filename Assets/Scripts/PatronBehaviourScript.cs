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
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "beer") // if the patron collides with beer, send him back
        {
            renderer.flipX = true;
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

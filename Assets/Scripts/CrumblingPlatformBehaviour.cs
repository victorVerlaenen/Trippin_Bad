using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingPlatformBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private const float crumblingDuration = 0.667f / 0.4f; // Got this from the animation duration
    private const float startDuration = 0.15f;
    private float counter = 0;
    private float initialCounter = 0;
    private bool playerIsOnPlatform = false;
    private bool start = false;
    private bool soundPlayed = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            initialCounter += Time.deltaTime;
            if (initialCounter > startDuration)
            {
                gameObject.GetComponent<Animator>().SetBool("Fall", true);
                if (!soundPlayed)
                { 
                    FindObjectOfType<AudioManager>().Play("CrumblingPlatform");
                    soundPlayed = true;
                }
                playerIsOnPlatform = true;
            }
        }
        if (playerIsOnPlatform)
        {
            counter += Time.deltaTime;
            if (counter > crumblingDuration)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        start = true;
    }
}

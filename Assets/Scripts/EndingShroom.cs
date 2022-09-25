using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingShroom : MonoBehaviour
{
    private bool startGame = false;
    private float timer = 0;
    private const float delay = 3;
    private bool soundPlaying = false;
    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            timer += Time.deltaTime;
            if (timer > delay)
            {
                SceneManager.LoadScene("EndScene");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(!soundPlaying)
            {
                FindObjectOfType<AudioManager>().Stop("MainTheme");
                FindObjectOfType<AudioManager>().Play("Win");
                soundPlaying = true;
            }
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            startGame = true;
        }
    }
}

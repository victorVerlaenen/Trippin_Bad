using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBehaviour : MonoBehaviour
{
    private const float twitchInterval = 7;
    [SerializeField] private float timer = 0;
    private Animator animator;
    private bool twitching = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(twitching)
        {
            animator.SetBool("Twitch", false);
            twitching = false;
        }
        timer += Time.deltaTime;
        if(timer > twitchInterval)
        {
            animator.SetBool("Twitch", true);
            timer = 0;
            twitching = true;
        }
    }
}

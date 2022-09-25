using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullBehaviour : MonoBehaviour
{
    [SerializeField] private Color color;
    private float cooldownMax = 1.0f;
    private float cooldownCurrent = 0.0f;
    private bool isOnCooldown = false;
    private Animator animator;
    public Color GetColor()
    {
        return color;
    }

    public bool GetCooldown()
    {
        return isOnCooldown;
    }
    public enum Color
    {
        Red,
        Blue,
        Green,
        Yellow,
        None
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Hit()
    {
        isOnCooldown = true;
        animator.SetBool("Hit", true);
        FindObjectOfType<AudioManager>().Play("SkeletonHit");
    }

    // Update is called once per frame
    void Update()
    {
        if(isOnCooldown)
        {
            cooldownCurrent += Time.deltaTime;
            Debug.Log(cooldownCurrent);
            if(cooldownCurrent >= cooldownMax - 0.33f)
            {
                animator.SetBool("Hit", false);
            }
            if(cooldownCurrent >= cooldownMax)
            {
                isOnCooldown = false;
                cooldownCurrent = 0;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float inputX;
    private Rigidbody2D theRigidbody;
    [SerializeField] private float jumpForce = 8.0f;
    private bool grounded = true;
    [SerializeField] private float moveSpeed = 5.0f;
    private Animator animator;

    [SerializeField] private Animation idleAnimation;
    [SerializeField] private Animation runAnimation;

    [SerializeField] private GameObject mainCamera;
    private bool onSkull = false;
    private SkullBehaviour.Color skullColor = SkullBehaviour.Color.None;
    private SkullBehaviour currentSkullBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        theRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        theRigidbody.velocity = new Vector2(inputX * moveSpeed, theRigidbody.velocity.y);

        if (theRigidbody.velocity.x > 0)
        {
            transform.rotation = Quaternion.identity;
            animator.SetBool("Run", true);
        }
        else if (theRigidbody.velocity.x < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            animator.SetBool("Run", true);
        }
        else animator.SetBool("Run", false);

        if (theRigidbody.velocity.y > 0)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Fall", false);
        }
        else if (theRigidbody.velocity.y < 0)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", true);
        }
        else
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", false);
        }
    }

    private void LateUpdate()
    {
        if (IsGrounded()) grounded = true;
        else grounded = false;
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }

    public void JumpA(InputAction.CallbackContext context)
    {
        if (grounded)
        {
            theRigidbody.velocity = new Vector2(theRigidbody.velocity.x, jumpForce);
            FindObjectOfType<AudioManager>().Play("Jump");
            skullColor = SkullBehaviour.Color.None;
        }
        else if (onSkull && !currentSkullBehaviour.GetCooldown())
        {
            if (skullColor != SkullBehaviour.Color.Green)
            {
                return;
            }
            theRigidbody.velocity = new Vector2(theRigidbody.velocity.x, jumpForce);
            FindObjectOfType<AudioManager>().Play("Jump");
            onSkull = false;
            skullColor = SkullBehaviour.Color.None;
            currentSkullBehaviour.Hit();
        }
    }
    public void JumpX(InputAction.CallbackContext context)
    {
        if (skullColor != SkullBehaviour.Color.Blue)
        {
            return;
        }
        if (onSkull && !currentSkullBehaviour.GetCooldown())
        {
            theRigidbody.velocity = new Vector2(theRigidbody.velocity.x, jumpForce);
            FindObjectOfType<AudioManager>().Play("Jump");
            onSkull = false;
            skullColor = SkullBehaviour.Color.None;
            currentSkullBehaviour.Hit();
        }
    }
    public void JumpY(InputAction.CallbackContext context)
    {
        if (skullColor != SkullBehaviour.Color.Yellow)
        {
            return;
        }
        if (onSkull && !currentSkullBehaviour.GetCooldown())
        {
            theRigidbody.velocity = new Vector2(theRigidbody.velocity.x, jumpForce);
            FindObjectOfType<AudioManager>().Play("Jump");
            onSkull = false;
            skullColor = SkullBehaviour.Color.None;
            currentSkullBehaviour.Hit();
        }
    }
    public void JumpB(InputAction.CallbackContext context)
    {
        if (skullColor != SkullBehaviour.Color.Red)
        {
            return;
        }
        if (onSkull && !currentSkullBehaviour.GetCooldown())
        {
            theRigidbody.velocity = new Vector2(theRigidbody.velocity.x, jumpForce);
            FindObjectOfType<AudioManager>().Play("Jump");
            onSkull = false;
            skullColor = SkullBehaviour.Color.None;
            currentSkullBehaviour.Hit();
        }
    }

    private bool IsGrounded()
    {
        if (theRigidbody.velocity.y == 0)
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Skull")
        {
            onSkull = true;
            skullColor = collision.gameObject.GetComponent<SkullBehaviour>().GetColor();
            currentSkullBehaviour = collision.gameObject.GetComponent<SkullBehaviour>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Skull")
        {
            onSkull = false;
            skullColor = SkullBehaviour.Color.None;
        }
    }
}

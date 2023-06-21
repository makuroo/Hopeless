using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 3f;

    private Rigidbody2D rb;

    private SpriteRenderer sr;

    private float lastHorizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    #region AnimationHandler
    private Animator animator;
    private void PlayWalk()
    {
        animator.SetBool("goWalk", true);
    }
    private void PlayJump()
    {
        animator.SetBool("goJump",true);
    }
    #endregion

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput!=0)
        {
            lastHorizontalInput = horizontalInput;
            PlayWalk();
        }
        else
        {
            animator.SetBool("goWalk", false);
        }

        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0));
        
        SpriteFlip(lastHorizontalInput);
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            PlayJump();
        }
    }

    private void SpriteFlip(float horizontalInput)
    {
        if(horizontalInput < 0)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
    }


}

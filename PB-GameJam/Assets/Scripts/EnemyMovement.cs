using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Moving back and forth variables
    public Vector3 horizontalVelocity;
    public float enemyMoveSpeed = 10f;
    public bool isMoving = true;
    public float moveBackTimer;
    bool moveBack = false;

    // Jumping only
    public bool onlyJumping = false;
    public float jumpTimer = 2f;

    // Can jump while moving
    public bool canJump = true;
    public Vector3 jumpVelocity;
    public float enemyJumpSpeed = 10f;
    Animator animator;

	private bool m_FacingRight = true;  // For determining which way the player is currently facing.

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            animator.SetBool("Walk", true);
            Move();
        }
        else
        {
            animator.SetBool("Walk", false);
        }
        if (onlyJumping && Time.time % jumpTimer == 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = (jumpVelocity * Time.deltaTime * enemyJumpSpeed);
        }
    }

    void Move()
    {
        if (Time.time % moveBackTimer == 0 && Time.time != 0)
        {
            moveBack = !moveBack;
            Flip();
        }

        if (moveBack)
        {
            transform.position += (-horizontalVelocity * Time.deltaTime * enemyMoveSpeed);
        }
        else
            transform.position += (horizontalVelocity * Time.deltaTime * enemyMoveSpeed);
        
    }
	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && canJump && gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
            gameObject.GetComponent<Rigidbody2D>().velocity = (jumpVelocity * Time.deltaTime * enemyJumpSpeed);
    }
}

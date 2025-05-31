using UnityEngine;

public class MoveLeftAndRight : MonoBehaviour
{
    public float moveSpeed = 6f;
    
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveDirection = 0f;

        // Check for input
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection = -1f; // Move left
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection = 1f; // Move right
            animator.SetBool("Left", false);
            animator.SetBool("Right", true);
        }
        else
        {
            // No key pressed — reset animation states
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }

        // Apply movement
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, 0f, 0f);
    }
}
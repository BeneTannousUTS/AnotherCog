using UnityEngine;

public class CogHelper : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;

    private Vector3 lastPosition;
    private Vector3 currentVelocity;
    private bool isAnimating = true;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        if (isAnimating)
        {
            rb.isKinematic = true;
            currentVelocity = (transform.position - lastPosition) / Time.deltaTime;
            lastPosition = transform.position;
        }
    }

    // Call this from animation event or timed trigger
    public void EnablePhysics()
    {
        isAnimating = false;

        // Sync rigidbody to final animated position
        rb.position = transform.position;
        rb.rotation = transform.rotation;

        rb.isKinematic = false;
        rb.linearVelocity = currentVelocity;
        // optionally add torque if it's spinning
    }
}

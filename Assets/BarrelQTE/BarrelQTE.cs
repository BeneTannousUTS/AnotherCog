using System.Collections;
using UnityEngine;

public class BarrelQTE : MonoBehaviour
{
    public Animator animator;
    private bool Jumping;
    private bool IsJumping = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsJumping){
            animator.SetTrigger("jump");
            IsJumping = true;
            StartCoroutine(jump());
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Jumping)
        {
            Destroy(other.gameObject);
        }
    }

    IEnumerator jump()
    {
        yield return new WaitForSeconds(0.200f);
        Jumping = true;
        yield return new WaitForSeconds(0.300f);
        Jumping =false;
        yield return new WaitForSeconds(0.367f);
        IsJumping = false;
    }
}

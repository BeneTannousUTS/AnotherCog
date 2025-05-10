using UnityEngine;

public class IKLookAt : MonoBehaviour
{
    Animator anim;
    public GameObject target;
    public float weight = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnAnimatorIK(int layerIndex)
    {
        anim.SetLookAtPosition(target.transform.position);
        anim.SetLookAtWeight(weight);
    }
}

using UnityEngine;

public class Scene2IK : MonoBehaviour
{
    private Animator anim;
    [SerializeField] GameObject target;
    
    float weight = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOnTracking()
    {
        weight = 1;
    }
    
    public void TurnOffTracking()
    {
        weight = 0;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetLookAtPosition(target.transform.position);
        anim.SetLookAtWeight(weight);
    }
}

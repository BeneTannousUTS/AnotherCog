using UnityEngine;

public class MoveForwards : MonoBehaviour
{
    public int speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(Vector3.back/speed);
        if (transform.position.z < -30)
        {
            Destroy(gameObject);
        }
    }
}

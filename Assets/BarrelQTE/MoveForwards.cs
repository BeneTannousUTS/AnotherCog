using UnityEngine;

public class MoveForwards : MonoBehaviour
{
    public int speed;
    public bool teleport;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(Vector3.back/speed);
        if (transform.position.z < -75)
        {
            if (teleport)
            {
                gameObject.transform.position += new Vector3(0, 0, 200);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

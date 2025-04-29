using UnityEngine;

public class GroundAndBarrel : MonoBehaviour
{
    public GameObject ground;
    public GameObject barrel;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            Instantiate(ground).transform.position = gameObject.transform.position;
            Instantiate(barrel).transform.position = gameObject.transform.position + new Vector3(0,0.25f,0);
            timer = 0;
        }
    }
}

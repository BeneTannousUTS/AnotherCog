using UnityEngine;

public class GroundAndBarrel : MonoBehaviour
{
    public GameObject ground;
    public GameObject barrel;
    private float timer;
    public bool spawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SpawnPipe()
    {
        Instantiate(ground).transform.position = gameObject.transform.position + new Vector3(-.45f, 0.3f, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                //Instantiate(ground).transform.position = gameObject.transform.position;
                Instantiate(barrel).transform.position = gameObject.transform.position + new Vector3(0, 0.25f, 0);
                Instantiate(barrel).transform.position = gameObject.transform.position + new Vector3(-1.5f, 0.25f, 0);
                timer = 0;
            }
        }
    }
}

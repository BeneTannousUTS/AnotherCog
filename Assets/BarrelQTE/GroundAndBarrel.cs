using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GroundAndBarrel : MonoBehaviour
{
    public GameObject ground;
    public GameObject barrel;
    private float timer;
    public Image jump;
    public bool spawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void QTE()
    {
        StartCoroutine(SpaceToJump());
    }

    IEnumerator SpaceToJump()
    {
        if (jump && jump.IsActive() == false)
        {

            yield return new WaitForSeconds(0.2f);
            jump.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.8f);
            jump.gameObject.SetActive(false);
        }
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
                GameObject b1 = Instantiate(barrel);
                b1.transform.position = gameObject.transform.position + new Vector3(0, 0.25f, 0);
                b1.GetComponent<MoveForwards>().jump = jump;
                GameObject b2 = Instantiate(barrel);
                b2.transform.position = gameObject.transform.position + new Vector3(-1.3f, 0.25f, 0);
                b2.GetComponent<MoveForwards>().jump = jump;
                timer = 0;
            }
        }
    }
}

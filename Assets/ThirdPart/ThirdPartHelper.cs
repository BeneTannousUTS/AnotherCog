using System.Collections;
using UnityEngine;

public class ThirdPartHelper : MonoBehaviour
{

    public Animator workerAnim, cogAnim, bossAnim;
    public GameObject bossHead;
    private float t = 0.0f, bossT = 0.0f;
    public Avatar fallAvatar;
    private bool isLookingAtBoss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("AnimationHelp");
    }

    // Update is called once per frame
    void Update()
    {
        cogAnim.speed = Mathf.Lerp(1, 0, t / 17);
        t += Time.deltaTime;
        if (isLookingAtBoss) {
            workerAnim.transform.GetComponent<IKLookAt>().weight = Mathf.Lerp(0,1, bossT/4);
            bossT += Time.deltaTime;
        }
    }

    public IEnumerator AnimationHelp() {
        yield return new WaitForSeconds(10);
        workerAnim.SetTrigger("tired");
        yield return new WaitForSeconds(6);
        workerAnim.transform.GetComponent<IKLookAt>().weight = 0;
        workerAnim.transform.GetComponent<IKLookAt>().target = bossHead;
        isLookingAtBoss = true;
        workerAnim.SetTrigger("fall");
    }
}
